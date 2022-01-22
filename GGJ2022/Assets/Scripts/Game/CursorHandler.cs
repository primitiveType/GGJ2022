using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{

    public static CursorHandler instance;
    //if you want it private do:
    [SerializeField]
    Texture2D cursor;


    public void HandCursor()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
}
