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
    // Start is called before the first frame update
    public void SelectPiece(SelectDollPart piece, DollSlot slot)
    {
        CurrentPieces[slot] = piece;
        if (CurrentPieces.Count == 6)
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
