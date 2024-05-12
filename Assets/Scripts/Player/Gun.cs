using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletImpact; // �Ѿ� ���� ȿ��
    ParticleSystem bulletEffect;   // �Ѿ� ��ƼŬ �ý���
    AudioSource bulletAudio;       // �Ѿ� �߻� ����
    public Transform crosshair;    // ũ�ν��� ���� �Ӽ�



    void Start()
    {
        // �Ѿ� ȿ�� ��ƼŬ �ý��� ������Ʈ ��������
        bulletEffect = bulletImpact.GetComponent<ParticleSystem>();
        // �Ѿ� ȿ�� ����� �ҽ� ������Ʈ ��������
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }


    void Update()
    {
        // ũ�ν���� ǥ��
        ARAVRInput.DrawCrosshair(crosshair);
        // ����ڰ� IndexTrigger ��ư�� ������
        if (ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger))
        {
            ARAVRInput.PlayVibration(ARAVRInput.Controller.RTouch);
            // �Ѿ� ����� ���
            bulletAudio.Stop();
            bulletAudio.Play();
            // Ray�� ī�޶��� ��ü���� �������� �����.
            Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
            // Ray�� �浹 ������ �����ϱ� ���� ���� ����
            RaycastHit hitInfo;
            // �÷��̾� ���̾� ������
            int playerLayer = 1 << LayerMask.NameToLayer("Player");
            // ��Ʈ ���̾� ������
            int noteLayer = 1 << LayerMask.NameToLayer("Note");

            int layerMask = playerLayer;

            // Ray�� ���. ray�� �ε��� ������ hitinfo�� ����.
            if (Physics.Raycast(ray, out hitInfo, 200, ~layerMask))
            {
                // �Ѿ� ���� ȿ�� ó��
                // �Ѿ� ����Ʈ�� ���� ���̸� ���߰� ���
                bulletEffect.Stop();
                bulletEffect.Play();
                // �ε��� ������ �������� �Ѿ��� ����Ʈ ������ ����
                bulletImpact.forward = hitInfo.normal;
                // �ε��� ���� �ٷ� ������ ����Ʈ�� ���̵��� ����
                bulletImpact.position = hitInfo.point;

                // ray�� �ε��� ��ü�� note ��� �ǰ� ó��
                if (hitInfo.transform.name.Contains("Note"))
                {
                    NoteManager note = hitInfo.transform.GetComponent<NoteManager>();
                    if (note)
                    {
                        note.OnDamageProcess();
                        ScoreManager._totalScore += 5;
                    }
                }
            }
        }
    }
}
