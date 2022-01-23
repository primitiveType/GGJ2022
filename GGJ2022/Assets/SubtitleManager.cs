using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviourSingleton<SubtitleManager>
{
    [SerializeField] private Text m_SubtitleTextPrefab;
    [SerializeField] private Transform m_Parent;

    private Queue<Subtitle> QueuedText { get; } = new Queue<Subtitle>();

    private Text CurrentText { get; set; }


    // Update is called once per frame
    void Update()
    {
        if (CurrentText == null && QueuedText.Count > 0)
        {
            var subtitle = QueuedText.Dequeue();
            CurrentText = CreateText(subtitle.Text);
            StartCoroutine(DestroyTextAfterTime(subtitle.Duration));
        }
    }

    private IEnumerator DestroyTextAfterTime(float seconds)
    {
        float startTime = Time.time;
        while (Time.time - startTime < seconds)
        {
            yield return null;
        }
        
        Destroy(CurrentText);
        CurrentText = null;
    }

    public void QueueText(string text, float time)
    {
        QueuedText.Enqueue(new Subtitle(text, time));
    }
    
    public void QueueText(Subtitle subtitle)
    {
        QueuedText.Enqueue(subtitle);
    }

    private Text CreateText(string subtitle)
    {
        Text textObj = Instantiate(m_SubtitleTextPrefab, m_Parent);
        textObj.text = subtitle;
        return textObj;
    }


}
public class Subtitle
{
    public Subtitle(string text, float duration)
    {
        Duration = duration;
        Text = text;
    }

    public string Text { get; }
    public float Duration { get; }
}