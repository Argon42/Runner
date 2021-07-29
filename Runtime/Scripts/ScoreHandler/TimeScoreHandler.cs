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

        public override void StartService() => _trackingEnable = true;
        public override void StopService() => _trackingEnable = false;
        public override void Pause() => _trackingEnable = false;
        public override void Resume() => _trackingEnable = true;
    }
}