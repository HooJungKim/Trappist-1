using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    /*점수 채점 방식
    탄환과 노트 충돌 시간 기준
    1. perfect 10점
    2. great 7점
    3. good 5점
    4. bad 1점
    5. X 0점

    먼저 탄환과 노트 스크립트 제작 필요
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

    // 충돌 시간 측정
    private void CheckHitTime()
    {
        if (_isHit)
        {
            _hitTime = Time.deltaTime;
        }
    }
    // 점수 채점
    private void CheckScore()
    {
        CheckHitTime();
        // 충돌 시간으로 점수 판정
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
    // 점수 저장
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

    // 점수 출력
    private void ShowScore()
    {
        _totalScore = _scoreList.Sum();
        
    }
}
