using UnityEngine;

public class ChessStateMachine
{
    public event StateChangedEvent StateChanged; 
    public ChessStateMachine()
    {
        CurrentState = new DefaultChessState();
    }

    private IMachineState CurrentState { get;  set; }

    public void Clicked(IInteractable interactable)
    {
        IMachineState newState = CurrentState.Clicked(interactable);
        EnterIfNewState(newState);
    }

    private void EnterIfNewState(IMachineState newState)
    {
        if (newState != CurrentState)
        {
            CurrentState.ExitState();
            CurrentState = newState;
            CurrentState.EnterState();
            StateChanged?.Invoke(this, new StateChangedEventArgs(CurrentState));
        }
    }

    public void Hover(IInteractable interactable)
    {
        IMachineState newState = CurrentState.Hover(interactable);
        EnterIfNewState(newState);
    }

    public void UnHover(IInteractable interactable)
    {
        IMachineState newState = CurrentState.UnHover(interactable);
        EnterIfNewState(newState);
    }
}