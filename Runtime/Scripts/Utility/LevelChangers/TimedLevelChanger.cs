using System;
using System.Collections.Generic;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class TimedLevelChanger : LevelChanger
    {
        [SerializeField] private GameTime gameTime;
        [SerializeField] private List<RunnerLevel> levels = new List<RunnerLevel>();

        private int _currentLevel;
        private float _startTime;

        private void Update()
        {
            if (ServiceEnabled == false)
                return;

            if (gameTime.CurrentTime > _startTime + levels[_currentLevel].LevelDuration)
            {
                _startTime = gameTime.CurrentTime;
                _currentLevel = (_currentLevel + 1) % levels.Count;
                ChangeLevel(levels[_currentLevel].Background, levels[_currentLevel].SpawnerData);
            }
        }

        protected override void OnStartService()
        {
            _currentLevel = 0;
            _startTime = 0;

            ChangeLevel(levels[0].Background, levels[0].SpawnerData);
        }

        [Serializable]
        public class RunnerLevel
        {
            [SerializeField] private LevelBackground background;
            [SerializeField] private AbstractSpawnerData spawnerData;
            [SerializeField] private float levelDuration;

            public LevelBackground Background => background;
            public AbstractSpawnerData SpawnerData => spawnerData;
            public float LevelDuration => levelDuration;
        }
    }
}