using System.Linq;
using UnityEditor;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class GameServicesWindow : EditorWindow
    {
        private Vector2 _scroll;

        [MenuItem("Tools/Games/Runner/ObstacleGenerator")]
        public static void ShowWindow()
        {
            var window = GetWindow<GameServicesWindow>();
            window.titleContent = new GUIContent(nameof(GameServicesWindow));
            window.Show();
        }

        private void OnGUI()
        {
            var services = FindObjectsOfType<GameService>(true)
                .GroupBy(s => s.gameObject)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.ToList());

            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            GUI.color = Color.white;
            foreach (var kvp in services)
            {
                GUI.color = kvp.Key.activeInHierarchy ? Color.green : Color.red;
                EditorGUILayout.LabelField(kvp.Key.name);
                GUI.color = Color.white;

                EditorGUI.indentLevel++;
                foreach (var service in kvp.Value)
                {
                    GUI.color = service.enabled ? Color.white : Color.red;
                    EditorGUILayout.ObjectField(service, typeof(GameService));
                    GUI.color = Color.white;
                }

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.EndScrollView();
        }
    }
}