using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip Clip;

    public void OnEnable() {
        Source.PlayOneShot(Clip);
    }
}
