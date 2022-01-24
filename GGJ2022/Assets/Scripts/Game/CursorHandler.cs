using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{

    public static CursorHandler instance;
    //if you want it private do:
    [SerializeField]
    Texture2D openHand,closedHand,ditheredCursor,inverseCursor;


    public void HandCursor()
    {
        Cursor.SetCursor(openHand, new Vector2(openHand.width / 2, openHand.height/2), CursorMode.Auto);
    }
    public void ClosedCursor()
    {
        Cursor.SetCursor(closedHand, new Vector2(closedHand.width / 2, closedHand.height / 2), CursorMode.Auto);
    }
    public void DitherCursor()
    {
        Cursor.SetCursor(ditheredCursor, Vector2.zero, CursorMode.Auto);
    }
    public void InverseCursor()
    {
        Cursor.SetCursor(ditheredCursor, Vector2.zero, CursorMode.Auto);
    }
}
