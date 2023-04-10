using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNote : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++){
            GameObject _instanceSamepleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSamepleCube.transform.position = this.transform.position;
            _instanceSamepleCube.transform.parent = this.transform;
            _instanceSamepleCube.name = "SampleCube" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
