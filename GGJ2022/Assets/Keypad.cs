using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string Answer;

    public InputField InputField;

    public UnityEvent OnSuccess;

    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip KeyPress;
    [SerializeField] private AudioClip Failure;
    [SerializeField] private AudioClip Success;


    // Start is called before the first frame update
    void Start()
    {
        InputField.text = "";
        InputField.onValueChanged.AddListener(InputChanged);
    }

    private void InputChanged(string arg0)
    {
        AudioSource.PlayOneShot(KeyPress);
        if (arg0 == Answer)
        {
            AudioSource.PlayOneShot(Success);
            OnSuccess.Invoke();
        }
        else if (InputField.text.Length >= Answer.ToString().Length)
        {
            AudioSource.PlayOneShot(Failure);
            InputField.text = "";
        }
    }
    
}