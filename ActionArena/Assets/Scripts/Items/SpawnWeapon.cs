using UnityEngine;
using Game.Weapons;


[RequireComponent(typeof(AudioSource))]
public class SpawnWeapon : MonoBehaviour
{
    [System.Serializable]
    public class SoundsSpawn
    {
        public AudioSource AudioSource;
        public AudioClip SoundRespawn;
        public AudioClip SoundPickup;
    }

    public Weapons m_Weapon;
    public GameObject m_Origen;
    public float m_respawnSeconds;
    public SoundsSpawn m_SoundsSpawn = new SoundsSpawn();

    private bool firstRespawn = true;
    private bool enable = true;
    private float time;
    private GameObject instance;

    // Use this for initialization
    private void Start()
    {
        if (m_Weapon != Weapons.None)
        {
            time = m_respawnSeconds;
            LoadPrefab();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (time >= m_respawnSeconds)
        {
            time = 0;
            enable = true;
            m_Origen.SetActive(true);

            if (firstRespawn)
                firstRespawn = !firstRespawn;
            else
                PlaySoundRespawn();

        }
         
        if (!enable)
            time += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (enable)
        {
            if (other.gameObject.tag == "Player")
            {
                var playerWeapons = other.GetComponent<PlayerWeapons>();
                playerWeapons.AddWeapon(m_Weapon);
                enable = false;
                m_Origen.SetActive(false);
                PlaySoundPickup();
            } 
        }
    }

    private void LoadPrefab()
    {
        // Create weapon from the prefabs
        instance = Instantiate(Resources.Load("W_" + m_Weapon.ToString(), typeof(GameObject))) as GameObject;
        instance.transform.position = m_Origen.transform.position;
        instance.transform.rotation = m_Origen.transform.rotation;
        instance.transform.parent = m_Origen.transform;
    }

    private void PlaySoundPickup()
    {
        m_SoundsSpawn.AudioSource.clip = m_SoundsSpawn.SoundPickup;
        m_SoundsSpawn.AudioSource.Play();
    }

    private void PlaySoundRespawn()
    {
        m_SoundsSpawn.AudioSource.clip = m_SoundsSpawn.SoundRespawn;
        m_SoundsSpawn.AudioSource.Play();
    }
}