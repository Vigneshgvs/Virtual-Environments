using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    public float speed;
    public Text countText;
    public Text winText;
    public bool cubeIsOnTheGround = true;
    public GameObject gameOverPanel;
    //public GameObject Countdown;
    public Text resultText;
    //public TextMesh countText2;

    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();        
    }

    // Update is called once per frame
    // Update - Game code
    void Update()
    {
        //jumping
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround) {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            cubeIsOnTheGround = false;
        }
        // falling to gravity
        if (rb.velocity.y < -12f){
            winText.text = "Fallen to gravity!";
            winText.color = Color.red;
            gameOverPanel.SetActive(true);
        }
    }
    //jumping
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground") {
            cubeIsOnTheGround = true;
        }
        //hit by caterpillar
        if (other.gameObject.tag == "Caterpillar") {
            //Debug.Log("clicked " + other.gameObject.name);
            //other.gameObject.SetActive(false);   //caterpillar inactive
            GameObject.Find("Player").SetActive(false);     //player inactive
            // game over
            winText.text = "Caught by Caterpillar!";
            winText.color = Color.red;
            gameOverPanel.SetActive(true);
        }
    }

    // FixedUpdate - Physics code
    void FixedUpdate() {
        //movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        //collecting Coins
        if (other.gameObject.CompareTag("Coin")) {
            other.gameObject.SetActive(false); 
            count = count+1;
            SetCountText();
        }
        //collecting Heart
        if (other.gameObject.CompareTag("Heart")) {
            other.gameObject.SetActive(false);
            // increase time 
           // Countdown.currentTime += 1800f;
           gameObject.GetComponent<Countdown>().currentTime += 1800f;       //accessing other class variables
        }        
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString() +"/18";
        if (count >= 18) {
            //finished
            winText.text = "You Won !!!";
            // resultText = GameObject.FindWithTag("Result")
            gameObject.GetComponent<Countdown>().currentTime += 1800f;
            gameOverPanel.SetActive(true);
            resultText.text = "Game Finished !!!";
            resultText.color = Color.green;
            
        }
        //countText2.text = "Count: " + count.ToString() + "/14";        
    }
}
