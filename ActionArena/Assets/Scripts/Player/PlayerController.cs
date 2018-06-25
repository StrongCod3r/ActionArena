using UnityEngine;


namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        public float speed = 8f;
        public float airControl = 2f;
        public float groundHeight = 1.5f;

        private Rigidbody rb;
        private Vector3 lookPos;
        private Vector3 movement;
        private float sleepTime;
        private bool enable;

        // Use this for initialization
        private void Start()
        {
            this.rb = base.GetComponent<Rigidbody>();
            enable = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (sleepTime > 0)
                sleepTime -= Time.deltaTime;
            else
            {
                sleepTime = 0;
                enable = true;
            }

        }

        private void FixedUpdate()
        {
            if (enable)
            {
                Move();
                Turn();
            }


        }

        private void Move()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            if (input != Vector3.zero)
            {
                movement = Camera.main.transform.TransformDirection(input);
                movement.y = 0f;


                if (IsGrounded())
                {
                    rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

                    //rb.AddForce(movement.normalized * speed, ForceMode.VelocityChange); 
                    //rb.MovePosition(transform.position + Vector3.MoveTowards(rb.velocity, movement, speed * Time.deltaTime));
                }
                else
                {
                    rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
                }
            }
        }

        private void Turn()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                this.lookPos = raycastHit.point;
            }
            Vector3 b = this.lookPos - base.transform.position;
            b.y = 0f;
            base.transform.LookAt(base.transform.position + b, Vector3.up);
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(base.transform.position, Vector3.down, this.groundHeight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        public void Sleep(float time)
        {
            sleepTime = time;
            enable = false;
        }

        public void Impulse(Vector3 direction, float thrust)
        {
            rb.AddForce(direction * thrust * rb.mass, ForceMode.Impulse);
        }
    } 
}