using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFront : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;

    [SerializeField]
    private float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = UnityEngine.Random.insideUnitSphere * tumble;
    }

    void Update()
    {      
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
