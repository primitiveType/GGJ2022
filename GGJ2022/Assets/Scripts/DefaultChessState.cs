public class DefaultChessState : IMachineState
{
    public IMachineState Clicked(IInteractable interactable)
    {
        if (interactable.Select(null))
        {
            return new ChessObjectSelectedState(interactable);
        }

        return this;//only enter selected state if the thing can be selected.
    }

    public IMachineState Hover(IInteractable piece)
    {
        piece.Highlight();
        return this;
    }

    public IMachineState UnHover(IInteractable chessPiece)
    {
        chessPiece.UnHighlight();
        return this;
    }

    public void ExitState()
    {
        
    }

    public void EnterState()
    {
        
    }
}