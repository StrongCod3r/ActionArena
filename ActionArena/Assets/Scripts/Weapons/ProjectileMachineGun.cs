using UnityEngine;

namespace Game.Weapons
{
    public class ProjectileMachineGun : ProjectileBase
    {
        public float m_TimeDestroy = 3;
        public float m_Radius = 5.0f;
        public float m_Power = 10.0f;
        public float m_ExplosiveLift = 1.0f;

        // Use this for initialization
        private void Start()
        {
            Destroy(this.gameObject, m_TimeDestroy);
        }

        // Update is called once per frame
        private void Update()
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var grenadeOrigin = transform.position;

            //this is saying that if any collider within the m_Radius of our object will feel the explosion
            Collider[] colliders = Physics.OverlapSphere(grenadeOrigin, m_Radius);

            foreach (var hit in colliders)
            {  //for loop that says if we hit any colliders, then do the following below

                if (hit.GetComponent<Rigidbody>())
                {
                    //if we hit any rigidbodies then add force based off our m_Power, the position of the explosion object
                    hit.GetComponent<Rigidbody>().AddExplosionForce(m_Power, grenadeOrigin, m_Radius, m_ExplosiveLift);

                    //the m_Radius and finally the explosive lift. Afterwards destroy the game object
                    Destroy(gameObject);

                }

            }
        }
    } 
}