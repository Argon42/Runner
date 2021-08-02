using UnityEngine;

namespace YodeGroup.Runner
{
    public abstract class CollisionTracker<T> : GameService where T : Component
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (ServiceEnabled == false)
                return;

            var component = other.gameObject.GetComponent<T>();
            if (component)
                CollisionHandler(component);
        }


        protected abstract void CollisionHandler(T component);
    }
}