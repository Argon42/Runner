using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class GameTime : GameService
    {
        private bool _isPaused;

        private CancellationTokenSource _source;
        private CancellationToken _token;

        public float CurrentTime { get; private set; }
        public float RealTime { get; private set; }
        public float GameSpeed { get; private set; }

        private void Update()
        {
            if (_isPaused)
                return;

            CurrentTime += Time.deltaTime * GameSpeed;
            RealTime += Time.deltaTime;
        }

        private void OnDestroy()
        {
            _source?.Cancel();
        }

        public override void StartService()
        {
            _source?.Cancel();

            _source = new CancellationTokenSource();
            _token = _source.Token;

            CurrentTime = 0;
            RealTime = 0;
            GameSpeed = 1;
            _isPaused = false;
        }

        public override void StopService()
        {
            _isPaused = true;
            _source.Cancel();
        }

        public override void Pause() => _isPaused = true;
        public override void Resume() => _isPaused = false;

        public async void SpeedUp(float multiplier, float duration)
        {
            if (multiplier <= 0)
                throw new ArgumentOutOfRangeException(nameof(multiplier), "is <= 0");

            if (duration <= 0)
                throw new ArgumentOutOfRangeException(nameof(duration), "is <= 0");

            float additionalSpeed = multiplier;
            GameSpeed += additionalSpeed;
            float startTime = RealTime;

            while (RealTime < startTime + duration)
            {
                if (_token.IsCancellationRequested)
                    return;

                await Task.Yield();
            }

            GameSpeed -= additionalSpeed;
        }
    }
}