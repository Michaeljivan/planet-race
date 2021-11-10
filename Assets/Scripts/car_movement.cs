using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class car_movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 35;
    public int rotationDegreeRight = 40;
    public int rotationDegreeLeft = -40;
    public Transform car;

    

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //private void FixedUpdate()
    void Update()
    {
        Vector3 forward = new Vector3(0, 0, 1);
        Vector3 backward = new Vector3(0, 0, -1);
        Vector3 steerRight = new Vector3(0, rotationDegreeRight, 0);
        Vector3 steerLeft = new Vector3(0, rotationDegreeLeft, 0);
        if (Input.GetKey("w"))
        {
            Debug.Log("Gas forward..");
            transform.Translate(forward * speed * Time.deltaTime);            
            car_behavior.Accelerate();
        }

        // Car boost
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log(".. current spd:" + speed );
            // Double the speed
            speed *= 2;
            transform.Translate(forward * (speed * 4) * Time.deltaTime);
            Debug.Log("Boost activated.. new spd:" + speed);
            car_behavior.Accelerate();
        }

        if (Input.GetKey("s"))
        {
            Debug.Log("Braking/backward..");
            transform.Translate(backward * speed * Time.deltaTime);
            car_behavior.Decelerate();
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

        if (Input.GetKey("space"))
        {
            Debug.Log("space button hit");
            Quaternion resetPostion = Quaternion.Euler(Vector3.zero);
            rb.MoveRotation(resetPostion);
        }
    }

    // On car collision
    private void OnCollisionEnter(Collision collision)
    {
        // Check for collision with a bus
        if (collision.gameObject.tag == "bus")
        {
            score_behavior.BusScore();
        }

        // Check for collision with a car
        if(collision.gameObject.tag == "car")
        {
            score_behavior.CarScore();
        }

        // Check for collision with van
        if(collision.gameObject.tag == "van")
        {
            score_behavior.VanScore();
        }

        // Check for collision with a truck
        if(collision.gameObject.tag == "truck")
        {
            score_behavior.TruckScore();
            Destroy(collision.gameObject);
        }
    }

}
