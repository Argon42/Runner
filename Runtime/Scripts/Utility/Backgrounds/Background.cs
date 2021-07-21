using System;
using System.Linq;
using DG.Tweening;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private Camera gameCamera;
        [SerializeField] private float duration;
        
        [SerializeField] private UnityEvent levelStarted;
        [SerializeField] private UnityEvent levelHidden;

        private float ScreenHeight => gameCamera.orthographicSize * 2;
        private float Height => BackgroundBounds().size.y;

        public void ShowLevel(float showDuration, Action callback = null)
        {
            transform.localPosition = Vector3.up * ScreenHeight;
            
        }

        public void StartScrollLevel(Action callback = null)
        {
            transform.localPosition = Vector3.zero;
            
            levelStarted?.Invoke();
        }

        public void HideLevel(float hideDuration, Action callback = null)
        {
            transform.localPosition = Vector3.down * (Height - ScreenHeight);
            
        }

        public void ResumeScroll()
        {
            transform.DOPlay();
        }

        public void PauseScroll()
        {
            transform.DOPause();
        }

        [ContextMenu(nameof(FoundBound))]
        private void FoundBound()
        {
            var bound = BackgroundBounds();
            Debug.Log($"center: {bound.center}, size:  {bound.size}");
            Debug.DrawLine(bound.min, bound.max, Color.red, 1);
        }

        private Bounds BackgroundBounds()
        {
            var allBounds = GetComponentsInChildren<SpriteRenderer>()
                .Select(spriteRenderer => spriteRenderer.bounds).ToList();
            var bounds = allBounds.FirstOrDefault();
            allBounds.ForEach(b => bounds.Encapsulate(b));
            return bounds;
        }
    }
}