using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class car_behavior : MonoBehaviour
{
    public GameObject mphText;
    public GameObject milesDrivenText;
    public GameObject driverNameText;

    private static int mph;
    private static double miles;

    public string driverName;

    // Start is called before the first frame update
    void Start()
    {
        driverNameText.GetComponent<Text>().text = driverName;
        mph = 0;
        miles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mphText.GetComponent<Text>().text =  "MPH " + mph;
        milesDrivenText.GetComponent<Text>().text = "Miles " + Math.Round(miles, 2);        
    }

    public static void Accelerate()
    {
        // add mileage
        if (miles < 100.0)
        {
            miles += 0.01;
        }

        // add 5 miles per hour to the speed.
        if (mph < 50)
        {
            mph += 5;
        }
        else
        {
            mph += 0;
        }
        
    }
    public static void Decelerate()
    {
        if(mph < 0)
        {
            mph = 0;
        }
        else
        {
            mph -= 5;
        }
        
    }
}
