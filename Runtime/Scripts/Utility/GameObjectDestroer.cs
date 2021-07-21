using System;
using UnityEngine;

namespace YodeGroup.Runner.Utility
{
    public class GameObjectDestroer : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(other.gameObject);
        }
    }
}