public class ChessObjectSelectedState : IMachineState
{
    public IInteractable CurrentSelected { get; private set; }
    public ChessObjectSelectedState(IInteractable selected)
    {
        CurrentSelected = selected;
    }
    public IMachineState Clicked(IInteractable interactable)
    {
        if (!ReferenceEquals(interactable, CurrentSelected) )
        {
            IInteractable prev = CurrentSelected;
            CurrentSelected = interactable;
            CurrentSelected.Select(prev);
            prev.UnSelect();
            return new DefaultChessState();
        }
        // else if (interactable is ChessSpace space)
        // {//don't unselect the piece if clicking a space.
        //     space.Select(null);
        // }
        return this;
    }

    public IMachineState Hover(IInteractable piece)
    {
        return this;
    }

    public IMachineState UnHover(IInteractable chessPiece)
    {
        return this;
    }

    public void ExitState()
    {
        CurrentSelected.UnSelect();
    }

    public void EnterState()
    {
        //CurrentSelected.Select(null);
    }
}