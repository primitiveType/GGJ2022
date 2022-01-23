public class StateChangedEventArgs
{
    public readonly IMachineState newState;

    public StateChangedEventArgs(IMachineState newState)
    {
        this.newState = newState;
    }
}