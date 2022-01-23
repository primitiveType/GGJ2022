public interface IInteractable
{
    void Highlight();
    void UnHighlight();
    bool Select(IInteractable previousSelected);
    void UnSelect();
}