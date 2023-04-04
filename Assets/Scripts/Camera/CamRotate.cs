using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 cameraAngle;

    private float angleXMin = -80.0f; // 카메라 x축 회전 범위 (최소)
    private float angleXMax = 50.0f; // 카메라 x축 회전 범위 (최대)

    [SerializeField] float rotateSpeed = 200.0f;
    //[SerializeField] float rotateSpeedY = 200.0f;

    void Start()
    {
        // 시작할 때 현재 카메라의 각도를 적용
        cameraAngle.x = -Camera.main.transform.eulerAngles.x;
        cameraAngle.y = Camera.main.transform.eulerAngles.y;
        cameraAngle.z = Camera.main.transform.eulerAngles.z;

    }


    void Update()
    {
        // 마우스의 좌우 입력을 가져온다.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 이동 공식에 대입해 각 속성별로 회전 값을 누적시킨다.
        cameraAngle.x -= mouseY * rotateSpeed * Time.deltaTime;
        cameraAngle.y += mouseX * rotateSpeed * Time.deltaTime;

        cameraAngle.x = Mathf.Clamp(cameraAngle.x, angleXMin, angleXMax);

        // 카메라의 회전 값에 새로 만들어진 회전 값을 할당한다.
        transform.eulerAngles = new Vector3(cameraAngle.x, cameraAngle.y, transform.eulerAngles.z);
    }
}
