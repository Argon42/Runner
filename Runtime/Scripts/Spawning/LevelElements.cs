using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class LevelElements : GameService
    {
        [SerializeField] private Spawner spawner;

        private readonly List<GameElement> _gameElements = new List<GameElement>();

        public void DestroyAllElements()
        {
            foreach (var element in GetElements())
                element.Disable();

            _gameElements.Clear();
        }

        public override void StartService()
        {
        }

        public override void StopService()
        {
            DestroyAllElements();
        }

        public override void Pause()
        {
            foreach (var element in GetElements())
                element.Pause();
        }

        public override void Resume()
        {
            foreach (var element in GetElements())
                element.Resume();
        }

        private void OnEnable()
        {
            spawner.ObstacleSpawned += OnElementSpawned;
            spawner.CollectableSpawned += OnElementSpawned;
        }

        private void OnDisable()
        {
            spawner.ObstacleSpawned -= OnElementSpawned;
            spawner.CollectableSpawned -= OnElementSpawned;
        }

        private IEnumerable<GameElement> GetElements()
        {
            _gameElements.RemoveAll(e => e == false);
            return _gameElements;
        }

        private void OnElementSpawned(GameElement obj)
        {
            _gameElements.Add(obj);
        }
    }
}