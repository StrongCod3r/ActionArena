using UnityEngine;

namespace Game.Weapons
{
    [RequireComponent(typeof(AudioSource))]
    public class WeaponMachineGun : WeaponBase
    {
        public WeaponMachineGun()
        {
            this.m_Speed = 75;
            this.m_Damage = 10;
        }

        // Use this for initialization
        private void Start()
        {
            name = Weapons.MachineGun.ToString();
            Id = Weapons.MachineGun;
            this.Munition = m_MunitionInitial;
            m_Muzzle.SetActive(false);
        }

    }
}