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

}
