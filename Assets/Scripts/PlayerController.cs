using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    float xInput;
    float yInput;

    int score = 0;
    public int winScore;
    public GameObject winText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5.0f)
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(xInput, 0, yInput) * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin collected");
            other.gameObject.SetActive(false);

            score++;

            if(score >= winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}
