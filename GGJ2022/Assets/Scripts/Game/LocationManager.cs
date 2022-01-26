using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationManager : MonoBehaviourSingleton<LocationManager>
{
    public Location StartingLocation;

    public Location CurrentLocation;
    private Location _lastLocation;
    public Camera CameraMain;

    public float TransitionDuration = 1.0f;

    // Start is called before the first frame update
    private List<Location> locations = new List<Location>();


    void Start()
    {
        var foundLocations = FindObjectsOfType<Location>();
        foreach (var location in foundLocations)
        {
            locations.Add((Location)location);
        }

        CurrentLocation = StartingLocation;
        Camera cam = StartingLocation.GetComponentInParent<Camera>();
        CameraMain.transform.position = cam.transform.position;
        CameraMain.transform.rotation = cam.transform.rotation;
        _lastLocation = CurrentLocation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public List<Location> GetLocations()
    {
        return locations;
    }

    public void SetLocation(Location location)
    {
        _lastLocation = CurrentLocation;
        CurrentLocation = location;
        Camera cam = location.GetComponentInParent<Camera>();
        CameraMain.transform.positionTo(TransitionDuration, cam.transform.position);
        CameraMain.transform.rotationTo(TransitionDuration, cam.transform.rotation);
    }

    public void GoUp()
    {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Up == null) return;

        SetLocation(CurrentLocation.Up);
    }

    public void GoRight()
    {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Right == null) return;

        SetLocation(CurrentLocation.Right);
    }

    public void GoDown()
    {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Down == null) return;

        SetLocation(CurrentLocation.Down);
    }

    public void GoLeft()
    {
        if (CurrentLocation == null) return;

        if (CurrentLocation.Left == null) return;

        SetLocation(CurrentLocation.Left);
    }

    public void Back() {
        SetLocation(_lastLocation);
    }
}