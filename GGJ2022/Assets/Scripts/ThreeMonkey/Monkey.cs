using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Monkey : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int Slot;
    // Start is called before the first frame update
    [SerializeField] private Material m_HighlightMaterial;

    private Material BaseMaterial { get; set; }
    public Renderer Renderer { get; private set; }
    private ThreeMonkey Manager { get; set; }

    void Start()
    {
        Manager = GetComponentInParent<ThreeMonkey>();
        Renderer = GetComponentInChildren<Renderer>();
        BaseMaterial = Renderer.material;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //highlight, show cursor
        //Manager.Hover(this);
        Highlight();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //Manager.UnHover(this);
        UnHighlight();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Manager.Clicked(this);
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
