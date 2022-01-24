using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
    LocationManager m_LocationManager;
    public GameObject Flashlight;

    public Button buttonUp, buttonDown, buttonLeft, buttonRight;

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
        if(Input.GetKeyUp("l")) {
            Flashlight.SetActive(!Flashlight.activeSelf);
        }
        if (m_LocationManager.CurrentLocation.Up == null)
        {
            buttonUp.GetComponent<Button>().enabled = false;
            buttonUp.GetComponent<Image>().enabled = false;
        }
        else
        {
            buttonUp.GetComponent<Button>().enabled = true;
            buttonUp.GetComponent<Image>().enabled = true;
        }
        if (m_LocationManager.CurrentLocation.Down == null)
        {
            buttonDown.GetComponent<Button>().enabled = false;
            buttonDown.GetComponent<Image>().enabled = false;
        }
        else
        {
            buttonDown.GetComponent<Button>().enabled = true;
            buttonDown.GetComponent<Image>().enabled = true;
        }
        if (m_LocationManager.CurrentLocation.Right == null)
        {
            buttonRight.GetComponent<Button>().enabled = false;
            buttonRight.GetComponent<Image>().enabled = false;
        }
        else
        {
            buttonRight.GetComponent<Button>().enabled = true;
            buttonRight.GetComponent<Image>().enabled = true;
        }
        if (m_LocationManager.CurrentLocation.Left == null)
        {
            buttonLeft.GetComponent<Button>().enabled = false;
            buttonLeft.GetComponent<Image>().enabled = false;
        }
        else
        {
            buttonLeft.GetComponent<Button>().enabled = true;
            buttonLeft.GetComponent<Image>().enabled = true;
        }
    }
    public void Upmovement()
    {
        m_LocationManager.GoUp();
    }
    public void Downmovement()
    {
        m_LocationManager.GoDown();
    }
    public void Leftmovement()
    {
        m_LocationManager.GoLeft();
    }
    public void Rightmovement()
    {
        m_LocationManager.GoRight();
    }
}
