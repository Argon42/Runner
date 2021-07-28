using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public abstract class LevelChanger : GameService
    {
        [SerializeField] private BackgroundScroller scroller;
        [SerializeField] private Spawner spawner;

        [SerializeField] private UnityEvent<LevelBackground> levelBackgroundChanged;
        [SerializeField] private UnityEvent<AbstractSpawnerData> spawnerDataChanged;

        public event UnityAction<LevelBackground> LevelBackgroundChanged
        {
            add => levelBackgroundChanged.AddListener(value);
            remove => levelBackgroundChanged.RemoveListener(value);
        }

        public event UnityAction<AbstractSpawnerData> SpawnerDataChanged
        {
            add => spawnerDataChanged.AddListener(value);
            remove => spawnerDataChanged.RemoveListener(value);
        }

        protected void ChangeLevel(LevelBackground levelBackground, AbstractSpawnerData spawnerData)
        {
            if (scroller)
                scroller.StartLevel(levelBackground);
            if (spawner)
                spawner.SetSpawnerData(spawnerData);

            levelBackgroundChanged?.Invoke(levelBackground);
            spawnerDataChanged?.Invoke(spawnerData);
        }
    }
}