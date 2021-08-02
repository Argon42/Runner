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

        protected override void OnStartService()
        {
            Score = 0;
            _trackingEnable = true;
        }

        protected override void OnStopService() => _trackingEnable = false;
        protected override void OnPause() => _trackingEnable = false;
        protected override void OnResume() => _trackingEnable = true;
    }
}