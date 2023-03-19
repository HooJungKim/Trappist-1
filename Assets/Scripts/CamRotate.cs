using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 cameraAngle;

    private float angleXMin = -80.0f; // ī�޶� x�� ȸ�� ���� (�ּ�)
    private float angleXMax = 50.0f; // ī�޶� x�� ȸ�� ���� (�ִ�)

    [SerializeField] float rotateSpeed = 200.0f;
    //[SerializeField] float rotateSpeedY = 200.0f;

    void Start()
    {
        // ������ �� ���� ī�޶��� ������ ����
        cameraAngle.x = -Camera.main.transform.eulerAngles.x;
        cameraAngle.y = Camera.main.transform.eulerAngles.y;
        cameraAngle.z = Camera.main.transform.eulerAngles.z;

    }


    void Update()
    {
        // ���콺�� �¿� �Է��� �����´�.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // �̵� ���Ŀ� ������ �� �Ӽ����� ȸ�� ���� ������Ų��.
        cameraAngle.x -= mouseY * rotateSpeed * Time.deltaTime;
        cameraAngle.y += mouseX * rotateSpeed * Time.deltaTime;

        cameraAngle.x = Mathf.Clamp(cameraAngle.x, angleXMin, angleXMax);

        // ī�޶��� ȸ�� ���� ���� ������� ȸ�� ���� �Ҵ��Ѵ�.
        transform.eulerAngles = new Vector3(cameraAngle.x, cameraAngle.y, transform.eulerAngles.z);
    }
}
