public interface IMachineState
{
    IMachineState Clicked(IInteractable interactable);
    IMachineState Hover(IInteractable piece);
    IMachineState UnHover(IInteractable chessPiece);

    void ExitState();
    void EnterState();
}