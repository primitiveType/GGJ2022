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
    }

    public void UnHighlight()
    {
    }

    public bool Select(IInteractable prev)
    {
        if (Manager.TryMoveToSpace(this, prev as ChessPiece))
        {
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