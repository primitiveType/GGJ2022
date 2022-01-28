using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light titleLight;
    public bool Flickering = false;
    public float timeDelay;

    private float[] smoothing = new float[20];
    private float sum = 150f;
    void Start()
    {
        for (int i = 0; i < smoothing.Length; i++)
        {
            smoothing[i] = .0f;
        }
    }

    void Update()
    {
        if (Flickering == false)
        {
            StartCoroutine(FlickeringLight());
        }

        float sum = 150.0f;

        for (int i = 1; i < smoothing.Length; i++)
        {
            smoothing[i - 1] = smoothing[i];
            sum += smoothing[i - 1];
        }

        smoothing[smoothing.Length - 1] = Random.value;
        sum += smoothing[smoothing.Length - 1];

        titleLight.intensity = sum / smoothing.Length*10;
       
    }
    IEnumerator FlickeringLight()
    {
        Flickering = true;
        titleLight.intensity = sum / smoothing.Length*10/2;
        timeDelay = Random.Range(0.01f, 5f);
        yield return new WaitForSeconds(timeDelay);

        titleLight.intensity = sum / smoothing.Length * 10;
        timeDelay = Random.Range(0.01f, 5f);
        yield return new WaitForSeconds(timeDelay);
        Flickering = false;
    }
}
