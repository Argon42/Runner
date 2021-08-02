using UnityEngine;

namespace YodeGroup.Runner
{
    public class TimeScoreHandler : ScoreHandler
    {
        [SerializeField] private GameTime gameTime;
        [SerializeField] private AnimationCurve timeToScore = AnimationCurve.Constant(0, 1, 3);

        private bool _trackingEnable;

        private void Update()
        {
            if (_trackingEnable == false) 
                return;

            Score = (int) timeToScore.Evaluate(gameTime.CurrentTime);
        }

        protected override void OnStartService() => _trackingEnable = true;
        protected override void OnStopService() => _trackingEnable = false;
        protected override void OnPause() => _trackingEnable = false;
        protected override void OnResume() => _trackingEnable = true;
    }
}