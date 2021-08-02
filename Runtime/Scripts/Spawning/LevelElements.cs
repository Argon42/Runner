using System.Collections.Generic;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class LevelElements : GameService
    {
        [SerializeField] private Spawner spawner;

        private readonly List<GameElement> _gameElements = new List<GameElement>();

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

        protected override void OnStopService() => DestroyAllElements();

        protected override void OnPause()
        {
            foreach (GameElement element in GetElements())
                element.Pause();
        }

        protected override void OnResume()
        {
            foreach (GameElement element in GetElements())
                element.Resume();
        }

        public void DestroyAllElements()
        {
            foreach (GameElement element in GetElements())
                element.Disable();

            _gameElements.Clear();
        }

        public IReadOnlyList<GameElement> GetElements()
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