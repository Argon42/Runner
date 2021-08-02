using System;
using System.Collections.Generic;
using UnityEngine;

namespace YodeGroup.Runner
{
    public abstract class AbstractSpawnerData : ScriptableObject
    {
        [SerializeField] private List<Obstacle> obstacles = new List<Obstacle>();
        [SerializeField] protected List<Collectable> collectables = new List<Collectable>();

        protected IReadOnlyList<Obstacle> Obstacles => obstacles;
        protected IReadOnlyList<Collectable> Collectables => collectables;

        public abstract float GetSpeed(float time);
        public abstract float GetSpawnDelay(float time);
        public abstract Obstacle GetObstacle();
        public abstract Obstacle GetObstacle(Func<Obstacle, bool> predicate);
        public abstract Collectable GetCollectable();
        public abstract GameElement GetGameElement(float time);
        public abstract Collectable GetCollectable(Func<Collectable, bool> predicate);
    }
}