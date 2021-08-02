using UnityEngine;

namespace YodeGroup.Runner
{
    public class GameTime : GameService
    {
        [SerializeField] private GameSpeed gameSpeed;

        private bool _isPaused;

        public float CurrentTime { get; private set; }
        public float RealTime { get; private set; }

        public float GameSpeed => gameSpeed.Speed;

        private void Update()
        {
            if (_isPaused)
                return;

            CurrentTime += Time.deltaTime * gameSpeed.Speed;
            RealTime += Time.deltaTime;
        }

        public override void StartService()
        {
            CurrentTime = 0;
            RealTime = 0;
            _isPaused = false;
        }

        public override void StopService() => _isPaused = true;
        public override void Pause() => _isPaused = true;
        public override void Resume() => _isPaused = false;
    }
}