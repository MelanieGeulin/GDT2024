using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CueController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 1f;
    [SerializeField]
    private float _hitForce = 10f;
    [SerializeField]
    private GameObject _cue;
    [SerializeField]
    private GameObject _ball;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

       
        transform.rotation *= Quaternion.Euler(0f, xInput * _rotationSpeed * Time.deltaTime, 0f);


        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Hit");
            _animator.SetTrigger("Hit");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Rigidbody rb = _ball.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError($"Missing rigidbody on {_ball.name}");
            }
            
            rb.AddForce(Vector3.forward * 10f, ForceMode.Impulse);
        }
    }
    public void PrintEvent()
    {
        Debug.Log("PrintEvent");
    }
    public void HitBall()
    {
        Debug.Log("PrintEvent");
        Vector3 direction = transform.position - _cue.transform.position;

        Rigidbody rb = _ball.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError($"Missing rigidbody on {_ball.name}");
        }
        rb.velocity = Vector3.zero;
        rb.AddForce(direction.normalized * _hitForce, ForceMode.Impulse);
    }
}
