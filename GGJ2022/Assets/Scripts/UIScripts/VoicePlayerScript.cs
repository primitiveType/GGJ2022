using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicePlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogPlayer.Instance.PlayClip("Escaped.wav");
    }

}
