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


    Transform player;
    // 공격 범위
    public float attackRange = 2.0f;


    [SerializeField]
    int hp = 1;
    //폭발 효과
    Transform explosion;
    ParticleSystem expEffect;
    AudioSource expAudio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        explosion = GameObject.Find("Explosion").transform;
        expEffect = explosion.GetComponent<ParticleSystem>();
        expAudio = explosion.GetComponent<AudioSource>();
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
                //Damaged();
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

    bool isCollisionSpaceShip = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Spaceship"))
        {
            isCollisionSpaceShip = true;
        }
    }
    private void Attack()
    {
        //if (Vector3.Distance(transform.position, player.position) < attackRange)
        if (isCollisionSpaceShip == true)
        {
            HPBar.Instance.HP -= Random.Range(5, 10);
            currentTime = 0;
            state = NoteState.Idle;
            isCollisionSpaceShip = false;
        }
    }
 
    IEnumerator Damage()
    {
        // 자식 객체의 MeshRenderer에서 재질 얻어오기
        Material mat = GetComponentInChildren<MeshRenderer>().material;
        // 원래 색을 저장
        Color originalColor = mat.color;
        // 재질의 색 변경
        mat.color = Color.red;
        // 0.1 초 기다리기
        yield return new WaitForSeconds(0.1f);
        // 재질의 색을 원래대로
        mat.color = originalColor;
        // 상태를 idle로 전환
        state = NoteState.Idle;
        // 경과 시간 초기화
        currentTime = 0;

    }

    public void OnDamageProcess()
    {
        state = NoteState.Damaged;
        StopAllCoroutines();
        StartCoroutine(Damage());
        // 폭발 효과의 위치 지정
        explosion.position = transform.position;
        // 이펙트 재생
        expEffect.Play();
        // 이펙트 사운드 재생
        expAudio.Play();
        // 노트 없애기
        Destroy(gameObject);
        // score 상승
        //ScoreManager._totalScore++;
    }

}
