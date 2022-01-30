using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogPlayer : MonoBehaviourSingleton<DialogPlayer>
{
    [SerializeField] private AudioSource Source;

    private void Start()
    {
        //PlayClip("beholderDie.mp3");
    }

    public void PlayClip(string name)
    {
        StartCoroutine(PlayClipAndSubtitles(name));
    }

    private IEnumerator PlayClipAndSubtitles(string name)
    {
        WWW request = new WWW(Path.Combine(Application.streamingAssetsPath, "Audio", name));
        yield return request;
        var clip = request.GetAudioClip();

        var subtitles = GetSubtitles(name);
        foreach (var subtitle in subtitles)
        {
            SubtitleManager.Instance.QueueText(subtitle);
        }

        Source.PlayOneShot(clip);
    }

    private List<Subtitle> GetSubtitles(string name)
    {
        var lines = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "Audio", name.Substring(0, name.LastIndexOf(".")) + ".sub"));
        List<Subtitle> subtitles = new List<Subtitle>();
        foreach (string line in lines)
        {
            int pipeIndex = line.IndexOf('|');
            int duration = int.Parse(line.Substring(0, pipeIndex));
            string text = line.Substring(pipeIndex + 1);
            subtitles.Add(new Subtitle(text, duration));
        }

        return subtitles;
    }
}