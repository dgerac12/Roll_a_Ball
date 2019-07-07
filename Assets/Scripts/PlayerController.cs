using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;

    public Text overText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        overText.text = "";

        score = 0;
        SetScoreText ();

        lives = 3;
        SetLivesText ();
    }

    void Update ()
    {
     if (lives == 0)
      { 
          Destroy(this);
          overText.text = "Game Over";
      }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Pick Up"))
      {
          other.gameObject.SetActive (false);
          count = count + 1;
          score = score + 1;
          SetCountText ();
          SetScoreText ();
          SetLivesText ();
      }

      if (score == 12)
      {
          transform.position = new Vector3(-60.0f, transform.position.y, 0.0f);
      }

      else if (other.gameObject.CompareTag("Enemy"))
      {
          other.gameObject.SetActive(false);
          
          count = count + 1;
          lives = lives - 1;
          SetCountText ();
          SetScoreText ();
          SetLivesText ();
      }
      
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (score >= 20) {
            winText.text = "You Win!";
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            GameObject.Destroy(enemy);

        }
    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString ();
    }

    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString ();
    }
}
