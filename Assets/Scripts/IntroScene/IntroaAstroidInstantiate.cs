using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroaAstroidInstantiate : MonoBehaviour
{
    public GameObject _Asteroid;

    [SerializeField]
    public float createTime = 1.0f;

    float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject _backgroundAsteroid = Instantiate(_Asteroid, transform.position, Quaternion.identity);
            Destroy(_backgroundAsteroid, 20.0f);
            currentTime = 0;
        }
    }
}
