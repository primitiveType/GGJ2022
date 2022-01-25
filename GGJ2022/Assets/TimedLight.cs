using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TimedLight : MonoBehaviour
{
    [SerializeField] private float period;
    [SerializeField] private float duration;
    [SerializeField] private float offset;
    [SerializeField] private Light m_Light;

    private float intensity;
    // Start is called before the first frame update
    void Start()
    {
        intensity = m_Light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        bool forward = true;
        float newRot = 0f;
        float remainder = (offset + ClockPuzzle.Instance.LightOffset + Time.time) % period;
        float timeLeft = Mathf.Max(0, duration - remainder);
        
      
        var progress = Mathf.PingPong(timeLeft, duration/2f);
        m_Light.intensity = Mathf.Lerp(0, intensity, progress > 0 ? 1 : 0);
    }
}
