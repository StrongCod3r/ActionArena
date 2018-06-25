using System;
using UnityEngine;
using System.Collections;

namespace Game.Weapons
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class WeaponBase : MonoBehaviour
    {
        [System.Serializable]
        public class SoundsWeapon
        {
            public AudioClip SoundShow;
            public AudioClip SoundReload;
            public AudioClip[] SoundFire = new AudioClip[0];
            public AudioClip[] SoundSilencer = new AudioClip[0];
        }

        public AudioSource m_ShootingAudio;
        public AudioClip m_ShootClip;
        private float lastFireTime = -1;


        public SoundsWeapon m_SoundsSetupPlayer = new SoundsWeapon();

        private uint munition;

        public GameObject m_Muzzle;
        public Rigidbody m_PrefabBullet;
        public float m_Frequency = 10;
        public uint m_MunitionMax = 100;
        public uint m_MunitionInitial;

        public uint m_Damage;
        public float m_Speed;

        private bool shoot = false;
        private Weapons id;

        public uint Munition
        {
            get{return munition;}
            set{
                munition += value;

                if (munition > m_MunitionMax)
                    munition = m_MunitionMax;
            }
        }

        public Weapons Id
        {
            get{return id;}
            protected set{id = value;}
        }

        public bool Shoot
        {
            get{ return shoot;}
            set{shoot = value;}
        }

        public WeaponBase()
        {
            Munition = m_MunitionInitial;
        }


        private void Update()
        {
            if (Shoot)
            {
                Fire();
            }
            else
                m_Muzzle.SetActive(false);

        }


        public virtual void Fire(Vector3 direction)
        {

        }

        //public virtual void Fire(Vector3 fromPos, Vector3 direction)
        public virtual void Fire()
        {
            if (Time.time > lastFireTime + 1 / m_Frequency)
            {
                if (Munition > 0)
                {
                    //m_Muzzle.SetActive(true);
                    Rigidbody bullet = Instantiate(m_PrefabBullet, m_Muzzle.transform.position, Quaternion.identity) as Rigidbody;

                    //shell.useGravity = true;
                    bullet.rotation = this.transform.rotation;
                    //bullet.velocity = m_Muzzle.transform.TransformDirection(0, 0, m_Speed);
                    bullet.AddForce(this.transform.forward * m_Speed * bullet.mass, ForceMode.Impulse);
                    Munition--;
                    m_ShootingAudio.clip = m_ShootClip;
                    m_ShootingAudio.Play();

                    m_Muzzle.SetActive(true);
                    AnimateMuzzle();
                    //UpdateFireEffect();
                }
                else
                {
                    // Reproduce sound of empty ammo
                    Munition = 0;
                    m_Muzzle.SetActive(false);
                }

                lastFireTime = Time.time;
            }

        }

        protected virtual void SpawnProjectile(Vector3 fromPos, Vector3 direction)
        {

        }

        protected virtual void Reload()
        {

        }

        public void AnimateMuzzle()
        {
            float f = /*(HasSilencer) ? Random.Range(0.35f, 0.5f) : */UnityEngine.Random.Range(0.95f, 1.1f);
            m_Muzzle.transform.localScale = new Vector3(f, f, f);
            m_Muzzle.transform.localEulerAngles = new Vector3(m_Muzzle.transform.localEulerAngles.x,
                                                            m_Muzzle.transform.localEulerAngles.y,
                                                            UnityEngine.Random.Range(0, 50));
        }

    }



}