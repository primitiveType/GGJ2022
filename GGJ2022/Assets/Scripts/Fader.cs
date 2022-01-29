using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    RawImage m_RawImage;
    private float fadeTime = 2f;
    private float holdTime = 15f;
    private float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_RawImage = GetComponent<RawImage>();
        m_RawImage.color = Color.black;
    }

    void OnEnable() {

    }

    // Update is called once per frame
    void Update()
    {
        if (t < holdTime) {
            m_RawImage.color = Color.Lerp(Color.black, Color.white, t/fadeTime);
        } else {
            m_RawImage.color = Color.Lerp(Color.white, Color.black, (t-holdTime)/fadeTime);
        }
        t += Time.deltaTime;

    }
}
