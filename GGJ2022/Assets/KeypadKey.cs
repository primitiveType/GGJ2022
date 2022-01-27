using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeypadKey : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string Value;
    [SerializeField] private Material m_HighlightMaterial;
    private Material BaseMaterial { get; set; }
    private Renderer Renderer { get; set; }
    private InputField InputField { get; set; }
    private Vector3 startPosition { get; set; }
    [SerializeField]private Vector3 clickDistance = Vector3.forward * .05f;
    [SerializeField]private float clickTime = 1f;
    private void Start()
    {
        startPosition = transform.localPosition;
        InputField = GetComponentInParent<Keypad>().InputField;
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
        StartCoroutine(ClickedMovement());
        InputField.text += Value;
    }

    public void Highlight()
    {
        Renderer.material = m_HighlightMaterial;
    }

    public void UnHighlight()
    {
        Renderer.material = BaseMaterial;
    }

    private IEnumerator ClickedMovement()
    {
        float t = 0;
        float final = clickTime;

        while (t < final)
        {
            transform.localPosition = Vector3.Lerp(startPosition, startPosition + clickDistance, t / clickTime);
            yield return null;
            t += Time.deltaTime;
        }

        t = 0;

        
        while (t < final)
        {
            transform.localPosition = Vector3.Lerp(startPosition + clickDistance, startPosition, t / clickTime);
            yield return null;
            t += Time.deltaTime;
        }

    }

}