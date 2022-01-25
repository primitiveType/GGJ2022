using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
    public GameObject Flashlight;

    public GameObject buttonUp, buttonDown, buttonLeft, buttonRight;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("up")) {
            LocationManager.Instance.GoUp();
        }
        if(Input.GetKeyUp("down")) {
            LocationManager.Instance.GoDown();
        }
        if(Input.GetKeyUp("right")) {
            LocationManager.Instance.GoRight();
        }
        if(Input.GetKeyUp("left")) {
            LocationManager.Instance.GoLeft();
        }
        if(Input.GetKeyUp("l")) {
            Flashlight.SetActive(!Flashlight.activeSelf);
        }
        
        UpdateButtons();
    }

    public void UpdateButtons()
    {
        var location = LocationManager.Instance.CurrentLocation;
        buttonUp.SetActive(location.Up != null);
        buttonDown.SetActive(location.Down != null);
        buttonLeft.SetActive(location.Left != null);
        buttonRight.SetActive(location.Right != null);
    }
    public void Upmovement()
    {
        LocationManager.Instance.GoUp();
    }
    public void Downmovement()
    {
        LocationManager.Instance.GoDown();
    }
    public void Leftmovement()
    {
        LocationManager.Instance.GoLeft();
    }
    public void Rightmovement()
    {
        LocationManager.Instance.GoRight();
    }
}
