using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFront : MonoBehaviour
{
    // 전진하는 스크립트, 속도 설정 가능
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
