namespace YodeGroup.Runner
{
    public class CollectableScoreHandler : ScoreHandler
    {
        private bool _trackingEnable;

        public void TrackCollision()
        {
            if (_trackingEnable)
                Score += 1;
        }

        public override void StartService()
        {
            Score = 0;
            _trackingEnable = true;
        }

        public override void StopService() => _trackingEnable = false;
        public override void Pause() => _trackingEnable = false;
        public override void Resume() => _trackingEnable = true;
    }
}