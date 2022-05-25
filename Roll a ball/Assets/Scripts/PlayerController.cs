using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    public float speed;
    public Text countText;
    public Text winText;
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
        
    }

    // FixedUpdate - Physics code
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            other.gameObject.SetActive(false); 
            count = count+1;
            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString() + "/14";
        if (count >= 14) {
            winText.text = "You Won !!!";
        }
        //countText2.text = "Count: " + count.ToString() + "/14";        
    }
}
