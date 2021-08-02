using UnityEngine;

namespace YodeGroup.Runner
{
    public class GameTime : GameService
    {
        [SerializeField] private GameSpeed gameSpeed;

        public float CurrentTime { get; private set; }
        public float RealTime { get; private set; }

        public float GameSpeed => gameSpeed.Speed;

        private void Update()
        {
            if (ServiceEnabled == false)
                return;

            CurrentTime += Time.deltaTime * gameSpeed.Speed;
            RealTime += Time.deltaTime;
        }

        protected override void OnStartService()
        {
            CurrentTime = 0;
            RealTime = 0;
        }
    }
}