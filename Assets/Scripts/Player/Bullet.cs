using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 1. 복셀이 날아갈 속도 속성
    public float speed = 5;
    // 복셀을 제거할 시간
    public float destroyTime = 3.0f;
    // 경과 시간
    float currentTime;

    //void Start()
    void OnEnable()
    {
        currentTime = 0;
        // 2. 랜덤한 방향을 찾는다.
        Vector3 direction = Random.insideUnitSphere;
        // 3. 랜덤한 방향으로 날아가는 속도를 준다.
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }
    
    
    void Update()
    {
        // 일정 시간이 지나면 복셀을 제거하고 싶다.
        // 1. 시간이 흘러야 한다.
        currentTime += Time.deltaTime;

        // 2. 제거 시간이 됐으니까.
        // 만약 경과 시간이 제거 시간을 초과했다면
        if (currentTime > destroyTime)
        {
            // 3. Bullet 비활성화
            gameObject.SetActive(false);
            // 4. 오브젝트 풀에 다시 넣기
            BulletMaker.bulletPool.Add(gameObject);
        }


    }
}
