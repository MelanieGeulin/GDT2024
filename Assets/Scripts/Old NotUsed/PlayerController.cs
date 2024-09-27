using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float _jumpForce;

    private KeyCode _jumpKey = KeyCode.Space;

    private Rigidbody rb;

    private float xInput;
    private float yInput;

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
        if (Input.GetKeyDown(_jumpKey))
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(xInput, 0, yInput) * speed * Time.fixedDeltaTime, ForceMode.Acceleration);

       
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
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
