using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviourSingleton<Flashlight>
{
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}