using System;
using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public class ObstacleCollisionTracker : CollisionTracker<Obstacle>
    {
        [SerializeField] private UnityEvent onCollision;

        protected override void CollisionHandler(Obstacle component)
        {
            onCollision?.Invoke();
            component.Disable();
        }
    }
}