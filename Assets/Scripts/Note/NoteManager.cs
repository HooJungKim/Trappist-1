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


    Transform player;
    // ���� ����
    public float attackRange = 2.0f;


    [SerializeField]
    int hp = 1;
    //���� ȿ��
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
        // �ڽ� ��ü�� MeshRenderer���� ���� ������
        Material mat = GetComponentInChildren<MeshRenderer>().material;
        // ���� ���� ����
        Color originalColor = mat.color;
        // ������ �� ����
        mat.color = Color.red;
        // 0.1 �� ��ٸ���
        yield return new WaitForSeconds(0.1f);
        // ������ ���� �������
        mat.color = originalColor;
        // ���¸� idle�� ��ȯ
        state = NoteState.Idle;
        // ��� �ð� �ʱ�ȭ
        currentTime = 0;

    }

    public void OnDamageProcess()
    {
        state = NoteState.Damaged;
        StopAllCoroutines();
        StartCoroutine(Damage());
        // ���� ȿ���� ��ġ ����
        explosion.position = transform.position;
        // ����Ʈ ���
        expEffect.Play();
        // ����Ʈ ���� ���
        expAudio.Play();
        // ��Ʈ ���ֱ�
        Destroy(gameObject);
        // score ���
        //ScoreManager._totalScore++;
    }

}
