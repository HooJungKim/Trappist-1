using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float timer;
    float interval;

    void Start()
    {
        timer = 0;
        interval = 10f;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0;
        }
    }
}
