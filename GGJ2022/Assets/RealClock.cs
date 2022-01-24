using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealClock : MonoBehaviour
{
    [SerializeField] private Transform m_HourHand;
    [SerializeField] private Transform m_MinuteHand;
 
    private float m_HourHandStartRotation;
    private float m_MinuteHandStartRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        m_HourHandStartRotation = m_HourHand.rotation.x;
        m_MinuteHandStartRotation = m_MinuteHand.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
