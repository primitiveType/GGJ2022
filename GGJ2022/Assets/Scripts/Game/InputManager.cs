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
        buttonUp.SetActive(location.Up != null && location.Up.isActiveAndEnabled);
        buttonDown.SetActive(location.Down != null && location.Down.isActiveAndEnabled);
        buttonLeft.SetActive(location.Left != null && location.Left.isActiveAndEnabled);
        buttonRight.SetActive(location.Right != null && location.Right.isActiveAndEnabled);
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
