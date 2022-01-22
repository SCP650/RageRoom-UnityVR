using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class RanButton: Editor
{
    override public void OnInspectorGUI()
    {
        GameManager colliderCreator = (GameManager)target;
        if (GUILayout.Button("Randomize"))
        {
            GameManager.i.Randomize();
        }
        DrawDefaultInspector();
    }
}