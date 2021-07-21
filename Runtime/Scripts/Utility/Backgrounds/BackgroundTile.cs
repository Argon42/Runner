using System.Linq;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class BackgroundTile : MonoBehaviour
    {
        [SerializeField] private float height;
        public float Height => height;


        [ContextMenu(nameof(FoundBound))]
        private void FoundBound()
        {
            var bound = BackgroundBounds();
            height = bound.size.y;

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

        public void SetActive(bool value) => gameObject.SetActive(value);
        public bool IsActive => gameObject.activeSelf;
    }
}