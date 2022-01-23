using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtCursorPosition : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        transform.LookAt(ray.direction + ray.origin);
    }
}