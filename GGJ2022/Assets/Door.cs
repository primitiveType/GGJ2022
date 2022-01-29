using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public float OpenDuration = 1.0f;
    public float CloseDuration = 1.0f;

    public void Open() {
        gameObject.transform.localRotationTo(OpenDuration, new Vector3(0, 135, 0));
    }

    public void Close() {
        gameObject.transform.localRotationTo(CloseDuration, new Vector3(0, 0, 0));
    }

}
