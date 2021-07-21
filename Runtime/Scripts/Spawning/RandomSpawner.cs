using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace YodeGroup.Runner
{
    public class RandomSpawner : Spawner
    {
        [SerializeField] private Transform lineStart;
        [SerializeField] private Transform lineEnd;
        [SerializeField] private Transform parent;

        private bool _isPaused;

        private AbstractSpawnerData _levelData;

        private float _spawnTime;
        private float _time;

        public override void Pause()
        {
            _isPaused = true;
        }

        public override void Resume()
        {
            _isPaused = false;
        }

        public override void StartService()
        {
            _time = 0;
            _spawnTime = 0;
            _isPaused = false;
        }

        public override void StopService()
        {
            _isPaused = true;
        }

        public override void SetSpawnerData(AbstractSpawnerData spawnerData)
        {
            _levelData = spawnerData;
        }

        private void Update()
        {
            if (_isPaused || _levelData == false)
                return;

            _time += Time.deltaTime;

            if (_time > _spawnTime)
            {
                SpawnGameElement(_time);
                _spawnTime = _time + _levelData.GetSpawnDelay(_time);
            }
        }

        private void SpawnGameElement(float time)
        {
            GameElement prefab = _levelData.GetGameElement(time);
            Vector3 position = Vector3.Lerp(lineStart.position, lineEnd.position, Random.value);
            GameElement gameElement = Instantiate(prefab, position, Quaternion.identity, parent);
            OnGameElementSpawned(gameElement);
        }
    }
}