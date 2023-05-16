using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // ������ ǥ�� UI
    public Transform damageUI;
    public Image damageImage;

    // UI �����Ÿ��� �ð�
    public float damageTime = 0.1f;
    
    // ������ ó���� ���� �ڷ�ƾ �Լ�
    IEnumerator DamageEvent()
    {
        // damageImage ������Ʈ Ȱ��ȭ
        damageImage.enabled = true;
        // damageTime ��ŭ ��ٸ���.
        yield return new WaitForSeconds(damageTime);
        // �ٽ� ������� ��Ȱ��ȭ�Ѵ�.
        damageImage.enabled = false;
    }

    //�÷��̾��� ���� HP
    int initialHP = 100;
    //���� hp ����
    int _hp = 0;
    //���� ü�� �����̴�
    public Slider hpSlider;

    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            // ������ ���� ���� �ڷ�ƾ ����
            StopAllCoroutines();
            // �����Ÿ��� ó���� �ڷ�ƾ ȣ��
            StartCoroutine(DamageEvent());

            // hp�� 0 �����̸� ����
            if(_hp <= 0)
            {
                // ���� ���� ó��
                Util.SwitchScene("GameOverScene");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _hp = initialHP;
        // ī�޶��� nearClipPlane ���� ����� �д�.
        float z = Camera.main.nearClipPlane + 0.01f;
        // damageUI ��ü�� �θ� ī�޶�� ����
        damageUI.parent = Camera.main.transform;
        // damageUI�� ��ġ�� X, Y�� 0, Z ���� ī�޶��� near ������ ����
        damageUI.localPosition = new Vector3(0, 0, z);
        // damageUI�� ������ �ʵ��� �ʱ⿡ ��Ȱ���� �� ���´�.
        damageImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = _hp;
    }

    public static HPBar Instance;

    private void Awake()
    {
        //�̱��� ��ü �� �Ҵ�
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
