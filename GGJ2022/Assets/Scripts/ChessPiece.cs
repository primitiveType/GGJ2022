using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChessPiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IInteractable
{
    private ChessGame Manager { get; set; }
    [SerializeField] private Material m_HighlightMaterial;
    private ChessSpace CurrentSpace { get; set; }
    public Renderer Renderer { get; private set; }
    private Material BaseMaterial { get; set; }
    [SerializeField] private ChessPieceType m_Type;
    [SerializeField] private Transform m_VisualTransform;

    private void Start()
    {
        Manager = GetComponentInParent<ChessGame>();
        Renderer = GetComponentInChildren<Renderer>();
        BaseMaterial = Renderer.material;
    }


    public void MoveToSpace(ChessSpace space)
    {
        Transform myTransform = transform;
        transform.SetParent(space.transform);
        myTransform.localPosition = Vector3.zero;
        myTransform.rotation = Quaternion.identity;
        myTransform.Rotate(0f, (float)RandomUtil.GetDouble() * 180, 0f);
        CurrentSpace = space;
    }

    public bool CanMoveToSpace(ChessSpace space)
    {
        if (space.GetComponentInChildren<ChessPiece>())
        {
            return false;
        }

        int diffX = Math.Abs(space.X - CurrentSpace.X);
        int diffY = Math.Abs(space.Y - CurrentSpace.Y);
        switch (m_Type)
        {
            case ChessPieceType.Pawn:
                return diffY == 1 && diffX == 0;
            case ChessPieceType.Knight:
                if (diffY == 1 && diffX == 2)
                {
                    return true;
                }

                if (diffX == 1 && diffY == 2)
                {
                    return true;
                }

                return false;
            case ChessPieceType.Bishop:
                return diffX == diffY;
            case ChessPieceType.Rook:
                return diffX == 0 || diffY == 0;
            case ChessPieceType.Queen:
                if (diffX == 0 || diffY == 0)
                    return true;
                if (diffX == diffY)
                    return true;

                return false;
            case ChessPieceType.King:
                return diffX <= 1 && diffY <= 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return true;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //highlight, show cursor
        Manager.Hover(this);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Manager.UnHover(this);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Manager.Clicked(this);
    }

    public void Highlight()
    {
        Renderer.material = m_HighlightMaterial;
    }

    public void UnHighlight()
    {
        Renderer.material = BaseMaterial;
    }


    public bool Select(IInteractable previousSelected)
    {
        m_VisualTransform.localPosition = Vector3.up * (.5f / 24);
        Manager.PieceSelected(this);
        return true;
    }

    public void UnSelect()
    {
        m_VisualTransform.localPosition = Vector3.zero;
        UnHighlight();
    }
}