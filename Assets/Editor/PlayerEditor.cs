using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMover))]
public class PlayerEditor : Editor
{

    /*SerializedProperty itemToSpawn;
    SerializedProperty maxNumberOfItemsInGame;

    SerializedProperty screenBuffer;

    SerializedProperty maxSpawnDelay;
    SerializedProperty minSpawnDelay;*/


    /*private void OnEnable()
    {
        itemToSpawn = serializedObject.FindProperty("itemToSpawn");
        maxNumberOfItemsInGame = serializedObject.FindProperty("maxNumOfItemsInGame");

        screenBuffer = serializedObject.FindProperty("buffer");

        maxSpawnDelay = serializedObject.FindProperty("maxSpawnDelay");
        minSpawnDelay = serializedObject.FindProperty("minSpawnDelay");
    }*/

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Reset Saved Values"))
        {
            PlayerMover.numberOfJumps = 0;
            PlayerMover.itemsBumped = 0;
        }
    }
}
