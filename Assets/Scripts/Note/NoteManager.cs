using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    // ��Ʈ ���� ��� ����
    enum NoteState
    {
        Idle,
        Attack,
        Damaged
    }

    // �ʱ� ���� ���´� Idle�� ����
    NoteState state = NoteState.Idle;
    // ��� ������ ���� �ð�
    public float idleDelyTime = 2;
    // ��� �ð�
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
