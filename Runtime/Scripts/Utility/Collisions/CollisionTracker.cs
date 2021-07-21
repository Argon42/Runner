using System;
using UnityEngine;

namespace YodeGroup.Runner
{
    public abstract class CollisionTracker<T> : GameService where T : Component
    {
        private bool _tracking;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_tracking == false) return;

            var component = other.gameObject.GetComponent<T>();
            if (component)
                CollisionHandler(component);
        }

        public override void StartService() => _tracking = true;

        public override void StopService() => _tracking = false;

        public override void Pause() => _tracking = false;

        public override void Resume() => _tracking = true;


        protected abstract void CollisionHandler(T component);
    }
}