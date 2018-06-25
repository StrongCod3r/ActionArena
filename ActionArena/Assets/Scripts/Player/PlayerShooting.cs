using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform m_OrigenShoot;
    public Rigidbody m_Shell;
    public float speed = 20;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    private void FixedUpdate()
    {

    }

    private void Shoot()
    {
        Rigidbody shell = Instantiate(m_Shell, m_OrigenShoot.position, m_OrigenShoot.rotation) as Rigidbody;

        //shell.useGravity = true;
        shell.velocity = m_OrigenShoot.transform.TransformDirection(0, 0, speed);
    }
    
}