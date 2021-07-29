using UnityEngine;

namespace YodeGroup.Runner
{
    public class RandomSpawner : Spawner
    {
        [SerializeField] private Transform lineStart;
        [SerializeField] private Transform lineEnd;
        [SerializeField] private Transform parent;

        [SerializeField] private GameTime gameTime;

        private bool _isPaused;
        private AbstractSpawnerData _levelData;
        private float _spawnTime;

        private void Update()
        {
            if (_isPaused || _levelData == false)
                return;

            if (gameTime.CurrentTime > _spawnTime)
            {
                SpawnGameElement(gameTime.CurrentTime);
                _spawnTime = gameTime.CurrentTime + _levelData.GetSpawnDelay(gameTime.CurrentTime);
            }
        }

        public override void StartService()
        {
            _spawnTime = 0;
            _isPaused = false;
        }

        public override void StopService() => _isPaused = true;
        public override void Pause() => _isPaused = true;
        public override void Resume() => _isPaused = false;

        public override void SetSpawnerData(AbstractSpawnerData spawnerData) => _levelData = spawnerData;

        private void SpawnGameElement(float time)
        {
            GameElement prefab = _levelData.GetGameElement(time);
            Vector3 position = Vector3.Lerp(lineStart.position, lineEnd.position, Random.value);
            GameElement gameElement = Instantiate(prefab, position, Quaternion.identity, parent);
            OnGameElementSpawned(gameElement);
        }
    }
}