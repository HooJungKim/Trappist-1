using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFront : MonoBehaviour
{
    public GameObject _Asteroid;
    // 전진하는 스크립트, 속도 설정 가능
    private float speed = 5.0f;

    public float createTime = 1.0f;
    float currentTime = 0;

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
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject _backgroundAsteroid = Instantiate(_Asteroid);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Destroy(_backgroundAsteroid, 20.0f);
            currentTime = 0;
        }
    }
}
