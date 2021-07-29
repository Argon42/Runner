using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public class SimpleCollectableCollisionTracker : CollisionTracker<SimpleCollectable>
    {
        [SerializeField] private UnityEvent onCollision;

        protected override void CollisionHandler(SimpleCollectable component)
        {
            onCollision?.Invoke();
            component.Disable();
        }
    }
}