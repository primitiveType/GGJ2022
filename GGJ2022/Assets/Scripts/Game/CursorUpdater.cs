using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorUpdater : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
    IPointerUpHandler
{
    public bool Interactable;

    public bool Moveable;
    private bool isOver;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        CursorHandler.Instance.HandCursor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        CursorHandler.Instance.ResetCursor();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CursorHandler.Instance.ClosedCursor();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isOver)
        {
            CursorHandler.Instance.HandCursor();
        }
        else
        {
            CursorHandler.Instance.ResetCursor();
        }
    }
}