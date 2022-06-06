using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //for text

public class Countdown : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 30f;
    public Text TimeText;
    public Text winText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //text
        TimeText.text = "Time (sec) Left: " + currentTime.ToString();

        if (currentTime <= 0) {
            currentTime = 0.0f;
            winText.text = "Time is up!";
            winText.color = Color.red;
            gameOverPanel.SetActive(true);
        }

    }
}
