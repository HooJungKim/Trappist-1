using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker : MonoBehaviour
{
    public GameObject bulletStorage;
    // ������Ʈ Ǯ�� ũ��
    public int bulletPoolSize = 20;
    //������Ʈ Ǯ
    public static List<GameObject> bulletPool = new List<GameObject>();
    public float createTime = 0.1f;
    float currentTime = 0;
    
    void Start()
    {
        // ������Ʈ Ǯ�� ��Ȱ��ȭ�� �ҷ��� ���
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletStorage);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    
    // ũ�ν���� ����
    public Transform crosshair;
    
    void Update()
    {
        // ũ�ν���� �׸���
        ARAVRInput.DrawCrosshair(crosshair);
        
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo) && ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger))
            {
                // ������Ʈ Ǯ�� �ҷ��� �ִٸ�
                if (bulletPool.Count > 0)
                {
                    currentTime = 0;
                    // ������Ʈ Ǯ���� �ҷ��� �ϳ� �����´�.
                    GameObject bullet = bulletPool[0];
                    bullet.SetActive(true);
                    bullet.transform.position = hitInfo.point;
                    bulletPool.RemoveAt(0);
                }
            }
        }
    }
}
