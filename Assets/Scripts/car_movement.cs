using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class car_movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 35;
    public Transform car;

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);
    Vector3 steerRight = new Vector3(0, 40, 0);
    Vector3 steerLeft = new Vector3(0, -40, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //private void FixedUpdate()
    void Update()
    {        
        if (Input.GetKey("w"))
        {
            Debug.Log("Gas forward..");
            transform.Translate(forward * speed * Time.deltaTime);
            score_behavior.AddScore();
            car_behavior.Accelerate();
        }

        if (Input.GetKey("s"))
        {
            car_behavior.Decelerate();
            Debug.Log("Braking/backward..");
            transform.Translate(backward * speed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            Debug.Log("Steering right..");
            Quaternion deltaRotationRight = Quaternion.Euler(steerRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

        if (Input.GetKey("a"))
        {
            Debug.Log("Steering left..");
            Quaternion deltaRotationLeft = Quaternion.Euler(steerLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }
    }
}
