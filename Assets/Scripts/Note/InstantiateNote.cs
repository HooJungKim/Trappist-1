using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNote : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;

    public GameObject _samplePrefab;
    GameObject[] _sampleCube = new GameObject[512];

    

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 512; i++){
        //    GameObject _instanceNote = (GameObject)Instantiate(_samplePrefab);
        //    _instanceNote.transform.position = this.transform.position;
        //    _instanceNote.transform.parent = this.transform;
        //    _instanceNote.name = "SampleNote" + i;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = new Vector3(transform.localScale.x, (AudioManager._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);

        if( (AudioManager._freqBand[_band] * _scaleMultiplier) > 10.0f )
        {
            GameObject _instanceNote = (GameObject)Instantiate(_samplePrefab);

            Destroy(_instanceNote, 5.0f);
        }
    }
}
