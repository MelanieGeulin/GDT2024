using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }
}
