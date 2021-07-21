using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class LifeSystemView : MonoBehaviour
    {
        [SerializeField] private List<Heart> _hearts = new List<Heart>();

        public void SetHealth(int currentHealth)
        {
            for (var i = 0; i < _hearts.Count; i++)
            {
                if(i < currentHealth)
                    _hearts[i].Enable();
                else
                    _hearts[i].Disable();
            }
        }

        public void SetMaxHealth(int maxHealth)
        {
            //TODO добавить возможность генерации новых сердец
            for (int i = 0; i < _hearts.Count; i++)
                _hearts[i].SetActive(i < maxHealth);
        }
    }
}