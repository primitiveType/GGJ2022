using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectDollPart : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private DollSlot Slot;
     public bool IsCorrect;

     private Vector3 startPosition;

     private void Start()
     {
         startPosition = transform.localPosition;
     }

     public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.localPosition == startPosition)
        {
            GetComponentInParent<DollPuzzle>().SelectPiece(this, Slot);
            transform.localPosition = Vector3.zero;
        }
        else
        {
            GetComponentInParent<DollPuzzle>().SelectPiece(null, Slot);
            transform.localPosition = startPosition;
        }
    }
}
