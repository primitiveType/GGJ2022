using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUpdater : MonoBehaviour
{
    CursorHandler cursorImage;
    // Start is called before the first frame update
    void Start()
    {
        cursorImage = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CursorHandler>();


    }

    public void OnMouseEnter()
    {
        if (gameObject.tag == "Interactable")
        cursorImage.InverseCursor();

        if (gameObject.tag == "Moveable")
        cursorImage.HandCursor();
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
