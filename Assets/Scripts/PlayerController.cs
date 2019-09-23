using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    // speed is public so it shows up in editor
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

        //call before physics
    void FixedUpdate()
    {
        float moveHorazontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorazontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

  
        // Destroy everything that enters the trigger
        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

        }
        if (other.gameObject.CompareTag("cap"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            SetCountText();
        }




    }

    void SetCountText()
    {

        countText.text = "Score: " + count.ToString();
        if (count>= 10)
        {
            winText.text = "YOU ARE WINNER!!!!";

        }
    }

    //Destroy(other.gameObject);

}
