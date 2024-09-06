using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _toFollow;
    [SerializeField]
    private float _smoothSpeed;
    [SerializeField]
    private Vector3 _offset;

    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = _toFollow.transform.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothSpeed * Time.fixedDeltaTime);
        transform.LookAt(_toFollow.transform.position);
    }
}
