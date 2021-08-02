using UnityEngine;

namespace YodeGroup.Runner
{
    public class RandomSpawner : Spawner
    {
        [SerializeField] private Transform lineStart;
        [SerializeField] private Transform lineEnd;
        [SerializeField] private Transform parent;

        [SerializeField] private GameTime gameTime;

        private AbstractSpawnerData _levelData;
        private float _spawnTime;

        private void Update()
        {
            if (ServiceEnabled == false || _levelData == false)
                return;

            if (gameTime.CurrentTime > _spawnTime)
            {
                SpawnGameElement(gameTime.CurrentTime);
                _spawnTime = gameTime.CurrentTime + _levelData.GetSpawnDelay(gameTime.CurrentTime);
            }
        }

        public override void SetSpawnerData(AbstractSpawnerData spawnerData) => _levelData = spawnerData;

        protected override void OnStartService() => _spawnTime = 0;

        private void SpawnGameElement(float time)
        {
            GameElement prefab = _levelData.GetGameElement(time);
            Vector3 position = Vector3.Lerp(lineStart.position, lineEnd.position, Random.value);
            GameElement gameElement = Instantiate(prefab, position, Quaternion.identity, parent);
            OnGameElementSpawned(gameElement);
        }
    }
}