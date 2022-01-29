using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public bool IsTimed = true;
    public Menu menuScript;
    bool isTiming = false;
    public float currentTime;
    public int startTime = 3;
    public Text currentTimeText;


    // Start is called before the first frame update
    void Start()
    {

        currentTime = startTime * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTiming == true)
        {
            currentTime = currentTime - Time.deltaTime;
        }
        if (currentTime <= .001f)
        {
            menuScript.GameOver();
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString("00");
    }
    public void StartTimer()
    {
        isTiming = true;
    }
    public void StopTimer()
    {
        isTiming = false;
    }
    public void Timing(bool IsTimed)
    {
        IsTimed = !IsTimed;
        this.gameObject.SetActive(IsTimed);
    }
}
