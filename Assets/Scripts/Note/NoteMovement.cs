using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    [SerializeField]
    private float _noteSpeed = 3.0f;

    //float xPosition = 0.0f;
    //float yPosition = 0.0f;
    //float zPosition = 0.0f;


    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    void Update()
    {
    
        transform.Translate(Vector3.back * Time.deltaTime * _noteSpeed);

    }
}
