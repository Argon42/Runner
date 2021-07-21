using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private UnityEvent started;
        [SerializeField] private UnityEvent ended;
        [SerializeField] private UnityEvent paused;
        [SerializeField] private UnityEvent resumed;

        private List<GameService> _services;

        public event UnityAction Started
        {
            add => started.AddListener(value);
            remove => started.RemoveListener(value);
        }

        public event UnityAction Ended
        {
            add => ended.AddListener(value);
            remove => ended.RemoveListener(value);
        }

        public event UnityAction Paused
        {
            add => paused.AddListener(value);
            remove => paused.RemoveListener(value);
        }

        public event UnityAction Resumed
        {
            add => resumed.AddListener(value);
            remove => resumed.RemoveListener(value);
        }

        private List<GameService> Services => 
            _services ??= FindObjectsOfType<GameService>(true).ToList();

        [ContextMenu(nameof(StartGame))]
        public void StartGame()
        {
            Services.ForEach(service => service.StartService());

            started?.Invoke();
        }

        [ContextMenu(nameof(EndGame))]
        public void EndGame()
        {
            Services.ForEach(service => service.StopService());

            ended?.Invoke();
        }

        [ContextMenu(nameof(Restart))]
        public void Restart()
        {
            Services.ForEach(service => service.StopService());

            StartGame();
        }

        [ContextMenu(nameof(Pause))]
        public void Pause()
        {
            Services.ForEach(service => service.Pause());

            paused?.Invoke();
        }

        [ContextMenu(nameof(Resume))]
        public void Resume()
        {
            Services.ForEach(service => service.Resume());

            resumed?.Invoke();
        }
    }
}