using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class RealClock : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform m_HourHand;
    [SerializeField] private Transform m_MinuteHand;
    [SerializeField] private Transform m_PendulumTransform;
    [SerializeField] private float m_PendulumPeriod = 2f;
    [SerializeField] private float m_PendulumOffset = 0f;
    [SerializeField] private float m_PendulumMaxRotation = 10f;
    [SerializeField] private Material m_HighlightMaterial;
    [SerializeField] private bool m_FreezingAffectsSwingTime;
    [SerializeField] private bool m_FreezingAffectsLightTime;
    [SerializeField] private bool m_IgnoreGlobalTime;
    private Material BaseMaterial { get; set; }

    public Renderer Renderer { get; private set; }

    private float m_HourHandStartRotation;
    private float m_MinuteHandStartRotation;

    // Start is called before the first frame update
    void Awake()
    {
        Renderer = GetComponentInChildren<Renderer>();
        BaseMaterial = Renderer?.material;
        m_HourHandStartRotation = m_HourHand.rotation.eulerAngles.x;
        m_MinuteHandStartRotation = m_MinuteHand.rotation.eulerAngles.x;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (frozen)
        {
            if (m_FreezingAffectsSwingTime)
            {
                // ClockPuzzle.Instance.SwingOffset -= Time.deltaTime;
                ClockPuzzle.Instance.SwingOffset -= Time.deltaTime;
            }

            if (m_FreezingAffectsLightTime)
            {
                ClockPuzzle.Instance.LightOffset -= Time.deltaTime;

            }
            
        }

        bool forward = true;
        float newRot = 0f;
        float outsideOffset = m_IgnoreGlobalTime ? 0 : ClockPuzzle.Instance.SwingOffset;
        float t = (Time.time + m_PendulumOffset + outsideOffset) % m_PendulumPeriod /
                  m_PendulumPeriod;
        forward = t >= .5f;
        if (forward)
        {
            newRot = Mathf.Lerp(-m_PendulumMaxRotation, m_PendulumMaxRotation, t);
        }
        else
        {
            newRot = Mathf.Lerp(m_PendulumMaxRotation, -m_PendulumMaxRotation, t);
        }

        m_PendulumTransform.rotation = Quaternion.Euler(-(m_PendulumMaxRotation / 2f) + newRot,
            m_PendulumTransform.rotation.eulerAngles.y, m_PendulumTransform.rotation.eulerAngles.z);

        var now = DateTime.Now;
        m_HourHand.rotation = Quaternion.Euler(m_HourHandStartRotation + GetRotationFromHours(now), 0, 0);
        m_MinuteHand.rotation = Quaternion.Euler(m_MinuteHandStartRotation + GetRotationFromMinutes(now), 0, 0);
    }

    private float GetRotationFromMinutes(DateTime now)
    {
        return (float)-(now.TimeOfDay.TotalMinutes / 60f) * 360;
    }

    private float GetRotationFromHours(DateTime now)
    {
        return (float)-((now.TimeOfDay.TotalHours % 12) / 12f) * 360;
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

    [SerializeField] private bool frozen;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        frozen = !frozen;
        if (frozen)
        {
            Highlight();
        }
        else
        {
            UnHighlight();
            
        }
    }

    public void Highlight()
    {
        Renderer.material = m_HighlightMaterial;
    }

    public void UnHighlight()
    {
        if(!frozen)
        Renderer.material = BaseMaterial;
    }
}