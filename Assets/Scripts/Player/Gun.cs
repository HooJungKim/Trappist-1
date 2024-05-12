using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletImpact; // 총알 파편 효과
    ParticleSystem bulletEffect;   // 총알 파티클 시스템
    AudioSource bulletAudio;       // 총알 발사 사운드
    public Transform crosshair;    // 크로스헤어를 위한 속성



    void Start()
    {
        // 총알 효과 파티클 시스템 컴포넌트 가져오기
        bulletEffect = bulletImpact.GetComponent<ParticleSystem>();
        // 총알 효과 오디오 소스 컴포넌트 가져오기
        bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }


    void Update()
    {
        // 크로스헤어 표시
        ARAVRInput.DrawCrosshair(crosshair);
        // 사용자가 IndexTrigger 버튼을 누르면
        if (ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger))
        {
            ARAVRInput.PlayVibration(ARAVRInput.Controller.RTouch);
            // 총알 오디오 재생
            bulletAudio.Stop();
            bulletAudio.Play();
            // Ray를 카메라의 위체에서 나가도록 만든다.
            Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
            // Ray의 충돌 정보를 저장하기 위한 변수 지정
            RaycastHit hitInfo;
            // 플레이어 레이어 얻어오기
            int playerLayer = 1 << LayerMask.NameToLayer("Player");
            // 노트 레이어 얻어오기
            int noteLayer = 1 << LayerMask.NameToLayer("Note");

            int layerMask = playerLayer;

            // Ray를 쏜다. ray가 부딪힌 정보는 hitinfo에 담긴다.
            if (Physics.Raycast(ray, out hitInfo, 200, ~layerMask))
            {
                // 총알 파편 효과 처리
                // 총알 이펙트가 진행 중이면 멈추고 재생
                bulletEffect.Stop();
                bulletEffect.Play();
                // 부딪힌 지점의 방향으로 총알의 이펙트 방향을 설정
                bulletImpact.forward = hitInfo.normal;
                // 부딪힌 지점 바로 위에서 이펙트가 보이도록 설정
                bulletImpact.position = hitInfo.point;

                // ray와 부딪힌 객체가 note 라면 피격 처리
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
