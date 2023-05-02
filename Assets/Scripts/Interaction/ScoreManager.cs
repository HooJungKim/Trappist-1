using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    /*���� ä�� ���
    źȯ�� ��Ʈ �浹 �ð� ����
    1. perfect 10��
    2. great 7��
    3. good 5��
    4. bad 1��
    5. X 0��

    ���� źȯ�� ��Ʈ ��ũ��Ʈ ���� �ʿ�
    */
    private int _score;
    private bool _isHit = false;
    private float _hitTime;
    private static int[] _scoreList = new int[999];
    public static int _totalScore;


    private void Update()
    {
        SaveScore();
        
        ShowScore();
    }

    // �浹 �ð� ����
    private void CheckHitTime()
    {
        if (_isHit)
        {
            _hitTime = Time.deltaTime;
        }
    }
    // ���� ä��
    private void CheckScore()
    {
        CheckHitTime();
        // �浹 �ð����� ���� ����
        if(_hitTime > 1)
        {
            _score = 0;
        }
        else if(_hitTime > 0.8)
        {
            _score = 1;
        }
        else if(_hitTime > 0.5)
        {
            _score = 5;
        }
        else if(_hitTime > 0.2)
        {
            _score = 7;
        }
        else
        {
            _score = 10;            
        }
    }
    // ���� ����
    private void SaveScore()
    {
        int i = 0;
        if (_isHit)
        {
            CheckScore();
            _scoreList[i] = _score;
            i++;
            _isHit = false;
        }
    }

    // ���� ���
    private void ShowScore()
    {
        _totalScore = _scoreList.Sum();
        
    }
}
