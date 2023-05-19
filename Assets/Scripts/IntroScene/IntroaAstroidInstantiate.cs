using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroaAstroidInstantiate : MonoBehaviour
{
    public GameObject _Asteroid;
    // �����ϴ� ��ũ��Ʈ, �ӵ� ���� ����
    [SerializeField]
    public float createTime = 1.0f;

    float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
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
