using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 position;

    private Vector3 tempPos;


    void Start()
    {
        transform.position = target.position + position;

    }

    void Update()
    {
        if (target != null)
        {
            tempPos = new Vector3(target.position.x + position.x, position.y, target.position.z + position.z);
            //transform.position = Vector3.Lerp(transform.position, tempPos, Time.deltaTime * 8);

            transform.position = tempPos;
            transform.LookAt(target);
        }

    }
}
