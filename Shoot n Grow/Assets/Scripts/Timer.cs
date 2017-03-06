using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timer;
    public float initialtime = 500.0f;

    private float start;
    private float remaining;

    // Use this for initialization
    void Start ()
    {
        start = Time.time;
    }
    
    // Update is called once per frame
    void Update ()
    {
        float temp = Time.time - start;

        remaining = initialtime - temp;

        if(remaining < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        timer.text = "Time Remaining: " + remaining.ToString("f0");

    }
}
