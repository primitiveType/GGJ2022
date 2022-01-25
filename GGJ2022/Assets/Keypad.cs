using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public int Answer;

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
        if (int.TryParse(InputField.text, out int input))
        {
        }
        else
        {
            return;
        }

        if (input == Answer)
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