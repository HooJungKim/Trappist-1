using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestParameter : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioManager._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}
