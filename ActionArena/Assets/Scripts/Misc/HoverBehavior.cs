using UnityEngine;
using System;
using System.Collections;

public class HoverBehavior : MonoBehaviour
{
    public Transform m_Object;
    public float m_RotationSpeed = 0;
    public float m_hoverSpeed = 0;
    //public float verticalSpeed = 1;
    public float m_Amplitude = 1;

    private float startPositionY;


    // Use this for initialization
    private void Start()
    {
        startPositionY = m_Object.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_RotationSpeed != 0)
            m_Object.Rotate(new Vector3(0, Time.deltaTime * m_RotationSpeed, 0));


        if (m_hoverSpeed != 0)
        {
            m_Object.position = new Vector3(
                                m_Object.position.x,
                                startPositionY + ((float)Math.Sin(Time.time) * ((m_Amplitude > 0) ? m_Amplitude : 1f)),
                                m_Object.position.z); 
        }
    }
}