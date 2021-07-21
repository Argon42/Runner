using UnityEngine;

namespace YodeGroup.Runner
{
    public abstract class LevelChanger : GameService
    {
        [SerializeField] private BackgroundScroller scroller;
        [SerializeField] private Spawner spawner;

        protected void ChangeLevel(LevelBackground levelBackground, AbstractSpawnerData spawnerData)
        {
            scroller.StartLevel(levelBackground);
            spawner.SetSpawnerData(spawnerData);
        }
    }
}