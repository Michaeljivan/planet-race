using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_behavior : MonoBehaviour
{
    private Text scoreText;
    private static int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + score;
    }
    
    // Score based on Gameobject
    public static void BasicScore()
    {
        // add points to base score
        score += 1;
    }
    public static void CarScore()
    {
        score += 4;
    }
    public static void VanScore()
    {
        score += 5;
    }
    public static void BusScore()
    {
        score += 6;
    }
    public static void TruckScore()
    {
        score += 9;
    }
    public static void GasScore()
    {
        score += 25;
    }
}
