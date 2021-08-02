using UnityEngine;

namespace YodeGroup.Runner
{
    public abstract class GameService : MonoBehaviour
    {
        public bool ServiceEnabled { get; private set; }

        public void StartService()
        {
            ServiceEnabled = true;
            OnStartService();
        }

        public void StopService()
        {
            ServiceEnabled = false;
            OnStopService();
        }

        public void Resume()
        {
            ServiceEnabled = true;
            OnResume();
        }

        public void Pause()
        {
            ServiceEnabled = false;
            OnPause();
        }

        protected virtual void OnStartService()
        {
        }

        protected virtual void OnStopService()
        {
        }

        protected virtual void OnResume()
        {
        }

        protected virtual void OnPause()
        {
        }
    }
}