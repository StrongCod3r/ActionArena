using System;
using UnityEngine;
using Game.Weapons;

public class PlayerHealth : MonoBehaviour
{
    #region Fields
    private int health;
    public UInt16 m_health = 100;
    public UInt16 m_HealthMax = 200;
    #endregion

    #region Properties
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    } 
    #endregion


    // Use this for initialization
    private void Start()
    {
        Health = m_health;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Health == 0)
            Dead();
    }

    private void FixedUpdate()
    {

    }

    public void Dead()
    {
        print("Player muerto");
    }
}