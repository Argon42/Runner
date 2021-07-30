﻿using UnityEngine;

namespace YodeGroup.Runner
{
    public class SimpleGameSpeed : GameSpeed
    {
        [SerializeField, Min(0)] private float speed = 1;

        public override float Speed => speed;

        public override void StartService()
        {
        }

        public override void StopService()
        {
        }

        public override void Pause()
        {
        }

        public override void Resume()
        {
        }
    }
}