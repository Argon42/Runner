using UnityEngine;

namespace YodeGroup.Runner
{
    public class Obstacle : GameElement
    {
        public override void Disable()
        {
            Destroy(gameObject);
        }

        public override void Pause()
        {
            Rigidbody.simulated = false;
        }

        public override void Resume()
        {
            Rigidbody.simulated = true;
        }
    }
}