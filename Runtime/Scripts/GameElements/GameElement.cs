using UnityEngine;

namespace YodeGroup.Runner
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class GameElement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        protected Rigidbody2D Rigidbody => _rigidbody = _rigidbody ? _rigidbody : GetComponent<Rigidbody2D>();

        public abstract void Disable();
        public abstract void Pause();
        public abstract void Resume();
    }
}