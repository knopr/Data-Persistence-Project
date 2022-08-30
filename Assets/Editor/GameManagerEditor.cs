using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GameManager script = (GameManager)target;
        if (GUILayout.Button("Reset highscores"))
        {
            GameManager.ResetHighScores();
        }
    }

}
