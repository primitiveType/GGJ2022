using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationManager : MonoBehaviour
{
    public List<Location> Locations = new List<Location>();
    public Location CurrentLocation;
    public Camera CameraMain;
    public float Duration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //m_CameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLocation(Location location) {
        CurrentLocation = location;
        Camera cam = location.GetComponentInParent<Camera>();
        CameraMain.transform.positionTo(Duration, cam.transform.position);
        CameraMain.transform.rotationTo(Duration, cam.transform.rotation);
    }

    public void GoUp() {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Up == null) return;

        SetLocation(CurrentLocation.Up);
    }

    public void GoRight() {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Right == null) return;

        SetLocation(CurrentLocation.Right);
    }
    public void GoDown() {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Down == null) return;

        SetLocation(CurrentLocation.Down);
    }
    public void GoLeft() {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Left == null) return;

        SetLocation(CurrentLocation.Left);
    }

}
