using UnityEngine;

namespace YodeGroup.Runner
{
    public abstract class GameService : MonoBehaviour
    {
        public abstract void StartService();
        public abstract void StopService();
        public abstract void Pause();
        public abstract void Resume();
    }
}