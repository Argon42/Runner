using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace YodeGroup.Runner.Editor
{
    public class ObstacleGenerator : EditorWindow
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private string assetFolderPath;

        [MenuItem("Tools/Games/Runner/ObstacleGenerator")]
        private static void ShowWindow()
        {
            var window = GetWindow<ObstacleGenerator>();
            window.titleContent = new GUIContent("ObstacleGenerator");
            window.Show();
        }

        private void OnGUI()
        {
            var serializedObject = new SerializedObject(this);

            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(prefab)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(sprites)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(assetFolderPath)));
            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Generate"))
                Generate();
            if (GUILayout.Button("SetupColliders"))
                SetupColliders();
        }

        private void SetupColliders()
        {
            foreach (var gameObject in Selection.gameObjects)
            {
                foreach (var spriteRenderer in gameObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    var coliider = spriteRenderer.GetComponent<Collider2D>();
                    if (coliider == false)
                        spriteRenderer.gameObject.AddComponent<PolygonCollider2D>();
                }
            }
        }

        private void Generate()
        {
            foreach (var sprite in sprites)
            {
                var instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                var spriteObject = new GameObject(sprite.name).AddComponent<SpriteRenderer>();
                spriteObject.sprite = sprite;
                spriteObject.transform.SetParent(instance.transform);
                spriteObject.transform.position = Vector3.zero;
                instance.name = sprite.name;
                var pathWithName = $"{assetFolderPath}/{sprite.name}.prefab";
                var variantPrefab = PrefabUtility.SaveAsPrefabAsset(instance, pathWithName);
                DestroyImmediate(instance);
            }
        }
    }
}