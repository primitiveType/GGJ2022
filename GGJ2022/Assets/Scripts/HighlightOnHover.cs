using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Renderer Renderer { get; private set; }
    private Material BaseMaterial { get; set; }
    [SerializeField] private Material m_HighlightMaterial;


    private void Start()
    {
        Renderer = GetComponentInChildren<Renderer>();
        BaseMaterial = Renderer.material;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //highlight, show cursor
        Highlight();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        UnHighlight();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
    }

    public void Highlight()
    {
        Renderer.material = m_HighlightMaterial;
    }

    public void UnHighlight()
    {
        Renderer.material = BaseMaterial;
    }
}