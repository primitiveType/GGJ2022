using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectDollPart : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private DollSlot Slot;
     public bool IsCorrect;

     private Vector3 startPosition;
     private Quaternion startRotation;

     private void Start()
     {
         startPosition = transform.localPosition;
         startRotation = transform.localRotation;
     }

     public void OnPointerClick(PointerEventData eventData)
    {
            GetComponentInParent<DollPuzzle>().SelectPiece(this, Slot);
    }

     public void UnselectPiece()
     {
         transform.localPosition = startPosition;
         transform.localRotation = startRotation;
     }

     public void SelectPiece()
     {
         transform.localPosition = Vector3.zero;
         transform.localRotation = Quaternion.identity;
     }
}
