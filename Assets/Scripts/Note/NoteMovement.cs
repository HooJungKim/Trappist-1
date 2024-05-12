using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    [SerializeField]
    private float _noteSpeed = 7.0f;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    void Update()
    {
    
        transform.Translate(Vector3.back * Time.deltaTime * _noteSpeed);

    }
}
