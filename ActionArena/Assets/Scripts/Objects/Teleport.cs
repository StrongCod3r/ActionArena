using UnityEngine;

public class Teleport : MonoBehaviour
{
    public bool enable = true;
    public Teleport teleportOut;
    public float thrust = 5;
    float disableTime = 0;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (disableTime > 0)
            disableTime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enable)
        {
            if (other.gameObject.name == "Player" && disableTime <= 0)
            {
                Teleport tp = teleportOut as Teleport;
                tp.disableTime = 1;

                other.transform.position = teleportOut.transform.position;
                other.transform.rotation = teleportOut.transform.rotation;

                var rb = other.GetComponent<Rigidbody>();
                rb.velocity = teleportOut.transform.forward * rb.velocity.magnitude;
                rb.AddForce(teleportOut.transform.forward * thrust / Time.deltaTime);
            }
            else if (other.gameObject.tag == "Bullet" && disableTime <= 0)
            {
                Teleport tp = teleportOut as Teleport;
                tp.disableTime = 1;

                other.transform.position = teleportOut.transform.position;
                var rb = other.GetComponent<Rigidbody>();
                rb.velocity = teleportOut.transform.forward * rb.velocity.magnitude;
            } 
        }
    }
}