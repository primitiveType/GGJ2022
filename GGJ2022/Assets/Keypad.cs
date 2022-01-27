using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string Answer;

    public InputField InputField;

    public UnityEvent OnSuccess;

    // Start is called before the first frame update
    void Start()
    {
        InputField.text = "";
        InputField.onValueChanged.AddListener(InputChanged);
    }

    private void InputChanged(string arg0)
    {
        if (arg0 == Answer)
        {
            //also play sound, etc.
            OnSuccess.Invoke();
        }
        else if (InputField.text.Length >= Answer.ToString().Length)
        {
            InputField.text = "";
        }
    }
    
}