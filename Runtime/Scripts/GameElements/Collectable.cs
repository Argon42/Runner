namespace YodeGroup.Runner
{
    public abstract class Collectable : GameElement
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