using UnityEngine;

namespace YodeGroup.Runner
{
    public class TimeScoreHandler : ScoreHandler
    {
        [SerializeField] private AnimationCurve timeToScore = AnimationCurve.Constant(0, 1, 3);
        
        private bool _trackingEnable;
        private float _time;

        public override void StartService()
        {
            _time = 0;
            _trackingEnable = true;
        }

        public override void StopService() => _trackingEnable = false;
        public override void Pause() => _trackingEnable = false;
        public override void Resume() => _trackingEnable = true;

        private void Update()
        {
            if(_trackingEnable == false) return;

            _time += Time.deltaTime;
            Score = (int) timeToScore.Evaluate(_time);
        }
    }
}