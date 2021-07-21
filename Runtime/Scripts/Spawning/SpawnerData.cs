using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace YodeGroup.Runner
{
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "Loyam/Games/Runner/SpawnerData")]
    public class SpawnerData : AbstractSpawnerData
    {
        [SerializeField] private AnimationCurve obstacleSpawnDelay = AnimationCurve.Constant(0, 1, 1);
        [SerializeField] private AnimationCurve obstacleSpeedCurve = AnimationCurve.Constant(0, 1, 3);
        [SerializeField] private AnimationCurve rateOfCollectableCurve = AnimationCurve.Constant(0, 1, 0.1f);

        public override float GetSpeed(float time)
        {
            return obstacleSpeedCurve.Evaluate(time);
        }

        public override float GetSpawnDelay(float time)
        {
            return obstacleSpawnDelay.Evaluate(time);
        }

        public override Obstacle GetObstacle()
        {
            return Obstacles[Random.Range(0, Obstacles.Count)];
        }

        public override Collectable GetCollectable()
        {
            return Collectables[Random.Range(0, Collectables.Count)];
        }

        public override GameElement GetGameElement(float time)
        {
            if (Random.Range(0, 1f) < rateOfCollectableCurve.Evaluate(time))
                return GetCollectable();
            else
                return GetObstacle();
        }
    }
}