using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LocationManager))]
public class LocationManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LocationManager myTarget = (LocationManager)target;
        foreach (var location in myTarget.Locations) {
            if (GUILayout.Button(location.name)) {
                myTarget.SetLocation(location);
            }
        }
    }
}
