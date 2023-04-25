using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 startPos;
    //private float repeatWidth;


    // Start is called before the first frame update
    void Start()
    {
        // ������ġ
        startPos = transform.position;
        //repeatWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �Ÿ� ��ŭ �̵� �� ����ġ�� ����
        if(transform.position.z - startPos.z >= 20)
        {
            transform.position = startPos;
        }
    }
}
