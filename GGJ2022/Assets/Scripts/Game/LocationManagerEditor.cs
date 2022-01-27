using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.EditorTools;

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

[EditorTool("Location Tool", typeof(Camera))]
class LocationTool : EditorTool {
    // Serialize this value to set a default value in the Inspector.
    [SerializeField]
    Texture2D m_ToolIcon;

    GUIContent m_IconContent;

    List<Location> locations = new List<Location>();

    private void Awake() {
        m_ToolIcon =  AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Textures/location_tool.png");
        locations.Clear();
        var objs = FindObjectsOfType<Location>();
        foreach (var loc in objs) {
            locations.Add((Location)loc);
        }
    }
    void OnEnable()
    {
        m_IconContent = new GUIContent()
        {
            image = m_ToolIcon,
            text = "Platform Tool",
            tooltip = "Platform Tool"
        };
    }

    public override GUIContent toolbarIcon
    {
        get { return m_IconContent; }
    }
    // This is called for each window that your tool is active in. Put the functionality of your tool here.
    public override void OnToolGUI(EditorWindow window)
    {
        Camera cam = (Camera)target;
        Handles.BeginGUI();
        {
            GUILayout.BeginArea(new Rect(0, 0, 100, 300), new GUIStyle("box"));
            {
                foreach (var location in locations) {
                    if (GUILayout.Button(location.name)) {
                        cam.transform.position = location.transform.position;
                        cam.transform.rotation = location.transform.rotation;
                    }
                }
            }
            GUILayout.EndArea();
        }
        Handles.EndGUI();
    }
}
#endif
