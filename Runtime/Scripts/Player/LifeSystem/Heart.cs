using System;
using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    [Serializable]
    public class Heart : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnable;
        [SerializeField] private UnityEvent onDisable;

        private bool _currentState;

        public void Enable()
        {
            if (_currentState == false)
                onEnable?.Invoke();
            _currentState = true;
        }

        public void Disable()
        {
            if (_currentState)
                onDisable?.Invoke();
            _currentState = false;
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}