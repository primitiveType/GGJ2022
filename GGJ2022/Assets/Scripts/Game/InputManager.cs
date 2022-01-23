using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    LocationManager m_LocationManager;
    // Start is called before the first frame update
    void Start()
    {
        m_LocationManager = FindObjectOfType<LocationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("up")) {
            m_LocationManager.GoUp();
        }
        if(Input.GetKeyUp("down")) {
            m_LocationManager.GoDown();
        }
        if(Input.GetKeyUp("right")) {
            m_LocationManager.GoRight();
        }
        if(Input.GetKeyUp("left")) {
            m_LocationManager.GoLeft();
        }

    }
}
