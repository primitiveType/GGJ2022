using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChessSpace : MonoBehaviour, IInteractable, IPointerClickHandler
{
    public int X { get; set; }
    public int Y { get; set; }
    private ChessGame Manager { get; set; }

    private void Start()
    {
        Manager = GetComponentInParent<ChessGame>();
    }

    public void Highlight()
    {
        CursorHandler.Instance.HandCursor();
    }

    public void UnHighlight()
    {
        CursorHandler.Instance.ResetCursor();
    }

    public bool Select(IInteractable prev)
    {
        if (Manager.TryMoveToSpace(this, prev as ChessPiece))
        {
            Manager.PieceMoved();
            return true;
        }

        return false;
    }

    public void UnSelect()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Manager.Clicked(this);
    }
}