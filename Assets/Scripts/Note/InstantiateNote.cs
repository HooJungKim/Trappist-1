using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNote : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;

    public GameObject _samplePrefab;
    GameObject[] _sampleCube = new GameObject[512];

    public float createTime = 1.0f;
    float currentTime = 0;

    void Update()
    {
        
        transform.localScale = new Vector3(transform.localScale.x, (AudioManager._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);

        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {

            if ((AudioManager._freqBand[_band] * _scaleMultiplier) > 10.0f)
            {
                GameObject _instanceNote = (GameObject)Instantiate(_samplePrefab, transform.position, Quaternion.identity);

                Destroy(_instanceNote, 5.0f);
            }

            currentTime = 0;
        }

    }
}
