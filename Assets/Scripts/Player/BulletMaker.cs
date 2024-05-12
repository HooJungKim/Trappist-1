using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker : MonoBehaviour
{
    public GameObject bulletStorage;
    // 오브젝트 풀의 크기
    public int bulletPoolSize = 20;
    //오브젝트 풀
    public static List<GameObject> bulletPool = new List<GameObject>();
    public float createTime = 0.1f;
    float currentTime = 0;
    
    void Start()
    {
        // 오브젝트 풀에 비활성화된 불렛을 담기
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletStorage);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    
    // 크로스헤어 변수
    public Transform crosshair;
    
    void Update()
    {
        // 크로스헤어 그리기
        ARAVRInput.DrawCrosshair(crosshair);
        
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo) && ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger))
            {
                // 오브젝트 풀에 불렛이 있다면
                if (bulletPool.Count > 0)
                {
                    currentTime = 0;
                    // 오브젝트 풀에서 불렛을 하나 가져온다.
                    GameObject bullet = bulletPool[0];
                    bullet.SetActive(true);
                    bullet.transform.position = hitInfo.point;
                    bulletPool.RemoveAt(0);
                }
            }
        }
    }
}
