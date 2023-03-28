using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        // 배경 크기 설정
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 배경 크기 만큼 이동 후 원위치로 복귀
        if(transform.position.x > startPos.x + repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
