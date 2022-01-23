using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(LocationManager))]
public class LocationManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LocationManager myTarget = (LocationManager)target;

        if (GUILayout.Button("Up")) {
            myTarget.GoUp();
        }
        using (var horizontalScope = new GUILayout.HorizontalScope("box"))
        {
            if (GUILayout.Button("Left")) {
                myTarget.GoLeft();
            }
            if (GUILayout.Button("Down")) {
                myTarget.GoDown();
            }
            if (GUILayout.Button("Right")) {
                myTarget.GoRight();
            }
        }
        GUILayout.Space(20);
        foreach (var location in myTarget.GetLocations()) {
            if (GUILayout.Button(location.name)) {
                myTarget.SetLocation(location);
            }
        }
    }
}
#endif
