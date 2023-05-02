using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    // 노트 상태 상수 정의
    enum NoteState
    {
        Idle,
        Attack,
        Damaged
    }

    // 초기 시작 상태는 Idle로 설정
    NoteState state = NoteState.Idle;
    // 대기 상태의 지속 시간
    public float idleDelyTime = 2;
    // 경과 시간
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case NoteState.Idle:
                Idle();
                break;
            case NoteState.Attack:
                Attack();
                break;
            case NoteState.Damaged:
                Damaged();
                break;
        }
    }

    private void Idle()
    {
        currentTime += Time.deltaTime;
        if (currentTime > idleDelyTime)
        {
            state = NoteState.Attack;
        }
    }
    private void Attack()
    {

    }
    private void Damaged()
    {

    }
}
