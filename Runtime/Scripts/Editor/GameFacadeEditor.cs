using System;
using UnityEditor;
using UnityEngine;

namespace YodeGroup.Runner
{
    [CustomEditor(typeof(GameFacade))]
    public class GameFacadeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space(20);
            if (GUILayout.Button($"Show {nameof(GameServicesWindow)}", GUILayout.Height(40)))
                GameServicesWindow.ShowWindow();
        }
    }
}