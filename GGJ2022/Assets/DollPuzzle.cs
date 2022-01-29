using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DollSlot
{
    Head,
    LeftArm,
    RightArm,
    LeftLeg,
    RightLeg,
    Tail
}

public class DollPuzzle : MonoBehaviour
{
    private Dictionary<DollSlot, SelectDollPart> CurrentPieces = new Dictionary<DollSlot, SelectDollPart>();

    public UnityEvent OnSuccess;
    
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip AudioClip;


    // Start is called before the first frame update
    public void SelectPiece(SelectDollPart piece, DollSlot slot)
    {
        AudioSource.PlayOneShot(AudioClip);
        if (CurrentPieces.TryGetValue(slot, out SelectDollPart currentPiece))
        {
            currentPiece?.UnselectPiece();
            CurrentPieces[slot] = null;
            if (piece == currentPiece)
            {
                return;
            }
        }

        CurrentPieces[slot] = piece;
        piece.SelectPiece();
        if (CurrentPieces.Count == 5)
        {
            foreach (var current in CurrentPieces.Values)
            {
                if (current == null || !current.IsCorrect)
                {
                    return;
                }
            }

            PuzzleSolved();
        }
    }

    private void PuzzleSolved()
    {
        OnSuccess.Invoke();
    }
}