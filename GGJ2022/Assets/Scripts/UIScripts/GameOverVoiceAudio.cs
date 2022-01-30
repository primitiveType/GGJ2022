using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverVoiceAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogPlayer.Instance.PlayClip("Timeout.wav");
    }

}
