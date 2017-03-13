using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timer;
    //public float initialtime = 500.0f;

    private float currenttime;
    private float displaytime;
    //private float remaining;
    
    // Update is called once per frame
    void Update ()
    {
        GameObject playerone = GameObject.Find("Player1");
        Player1Controller oneaccess = playerone.GetComponent<Player1Controller>();

        GameObject playertwo = GameObject.Find("Player2");
        Player2Controller twoaccess = playertwo.GetComponent<Player2Controller>();

        currenttime = Time.timeSinceLevelLoad;

        if(!oneaccess.levelComplete && !twoaccess.levelComplete)
            displaytime = currenttime;

        //Original script for timer.
        //float temp = Time.time - start;

        //remaining = initialtime - temp;

        //if(remaining < 0)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

        timer.text = "Time Elapsed: " + displaytime.ToString("f0");


    }
}
