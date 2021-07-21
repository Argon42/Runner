using System;
using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public abstract class ScoreHandler : GameService
    {
        [SerializeField] private UnityEvent<int> scoreChanged;

        private int _score;

        public int Score
        {
            get => _score;
            protected set
            {
                _score = value;
                scoreChanged?.Invoke(_score);
            }
        }
    }
}