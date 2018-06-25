using UnityEngine;
using Game.Player;
namespace Game.Objects
{
    public class Impulse : MonoBehaviour
    {
        public float thrust = 5;
        public bool enable = true;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (enable)
            {
                if (other.gameObject.name == "Player")
                    other.GetComponent<PlayerController>().Impulse(transform.forward, thrust);
            }
        }
    } 
}