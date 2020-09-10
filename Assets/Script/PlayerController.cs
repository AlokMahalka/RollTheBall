using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public LayerMask groundlayer;
    public float jumpForce = 7;
    public SphereCollider col;
    public Text countText;
    public Text winText;
    public Text countdown;
    public float timeLeft = 30.0f;
    public int flag = 0;
    public int maxcount;
    public int levelno;
    private Rigidbody rb;
    private int count;
    private int jumpcount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        count = 0;
        SetCountText();
        jumpcount = 1;
        winText.text = "";
        levelno = 1;

}

void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && jumpcount <= 2)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpcount = jumpcount + 1;
        }

    }

    void Update ()
    {
        timeLeft -= Time.deltaTime;
        countdown.text = timeLeft.ToString();
        if (timeLeft <= 0)
            GameOver();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("ground"))
        {
            jumpcount = 1;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= maxcount)
        {
            winText.text = "You Win!";
          
            //timeLeft = 0.0f;
            levelno++;
            NewLevel();
        }
    }

  
    private void NewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void GameOver()
    {
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }
    
}




  





