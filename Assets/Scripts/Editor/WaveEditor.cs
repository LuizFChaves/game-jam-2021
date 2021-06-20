
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnerController))]
public class WaveEditor : Editor{
    public override void OnInspectorGUI() {
        SpawnerController mapGen = (SpawnerController)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Create wave")) {
            mapGen.createWave();
        }

    }

}