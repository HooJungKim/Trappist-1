using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFront : MonoBehaviour
{
    // 전진하는 스크립트, 속도 설정 가능
    [SerializeField]
    private float speed = 20.0f;

    [SerializeField]
    private float tumble;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = UnityEngine.Random.insideUnitSphere * tumble;
    }


    // Update is called once per frame
    void Update()
    {      
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
