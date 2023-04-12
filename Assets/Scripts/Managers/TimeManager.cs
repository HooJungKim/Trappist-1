using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float timer;
    float interval;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        interval = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            //AssetMgr.timeCheck++;
            timer = 0;
        }
    }
}
