using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YodeGroup.Runner
{
    public abstract class Spawner : GameService
    {
        public event Action<Obstacle> ObstacleSpawned;
        public event Action<Collectable> CollectableSpawned;

        protected void OnCollectableSpawned(Collectable obj)
        {
            CollectableSpawned?.Invoke(obj);
        }

        protected void OnObstacleSpawned(Obstacle obj)
        {
            ObstacleSpawned?.Invoke(obj);
        }

        protected void OnGameElementSpawned(GameElement gameElement)
        {
            if (gameElement is Obstacle obstacle)
                OnObstacleSpawned(obstacle);
            else if (gameElement is Collectable collectable)
                OnCollectableSpawned(collectable);
        }

        public abstract void SetSpawnerData(AbstractSpawnerData spawnerData);
    }
}