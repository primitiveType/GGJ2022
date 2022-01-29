using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickToGainFlashlight : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Material m_HighlightMaterial;
    public UnityEvent OnSuccess;
    private Material BaseMaterial { get; set; }
    private Renderer Renderer { get; set; }

    

    private void Start()
    {
        Renderer = GetComponentInChildren<Renderer>();
        BaseMaterial = Renderer.material;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Highlight();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        UnHighlight();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Flashlight.Instance.SetActive(true);
        OnSuccess.Invoke();
        gameObject.SetActive(false);
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