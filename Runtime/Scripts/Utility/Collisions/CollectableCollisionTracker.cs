using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public class CollectableCollisionTracker : CollisionTracker<Collectable>
    {
        [SerializeField] private UnityEvent onCollision;

        protected override void CollisionHandler(Collectable component)
        {
            onCollision?.Invoke();
            component.Disable();
        }
    }
}