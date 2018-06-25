using UnityEngine;
using System;
using System.Collections.Generic;
using Game.Weapons;


public class PlayerWeapons : MonoBehaviour
{
    public Transform m_OrigenWeapon;

    private List<WeaponBase> weapons;
    private WeaponBase activeWeapon;

    // Use this for initialization
    private void Start()
    {
        weapons = new List<WeaponBase>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot(true);

        if (Input.GetKeyUp(KeyCode.Mouse0))
            Shoot(false);

    }

    private void FixedUpdate()
    {

    }

    private void Shoot(bool shoot)
    {
        if (activeWeapon)
        {
            activeWeapon.Shoot = shoot;
        }
            
    }

    public bool AddWeapon(Weapons weapon)
    {
        bool retValue = true;
        //bool addSuccesWeapon;
        if (!ExistWeapon(weapon))
        {
            // Create weapon from the prefabs
            GameObject instance = Instantiate(Resources.Load("Weapons\\" + weapon.ToString(), typeof(GameObject))) as GameObject;
            
            if (instance != null)
            {
                instance.transform.position = m_OrigenWeapon.position;
                instance.transform.rotation = m_OrigenWeapon.rotation;
                instance.transform.parent = m_OrigenWeapon;

                // Add weapon to the list
                WeaponBase w = null;
                switch (weapon)
                {
                    case Weapons.Gauntlet:
                        w = instance.GetComponent<WeaponMachineGun>();
                        break;
                    case Weapons.MachineGun:
                        w = instance.GetComponent<WeaponMachineGun>();
                        break;
                    default:
                        retValue = false;
                        break;
                }

                weapons.Add(w);
                activeWeapon = w;
            }
            else
            {
                Debug.LogError("No se ha podido cargar el fichero del arma: " + weapon.ToString());
                retValue = false;
            }
            return retValue;
        }

        return !retValue;
    }

    private WeaponBase ExistWeapon(Weapons weapon)
    {
        foreach (WeaponBase w in weapons)
        {
            if (w.Id == weapon)
                return w;
        }

        return null;
    }



}