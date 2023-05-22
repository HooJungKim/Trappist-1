using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuClear : MonoBehaviour
{
    
    public static bool isClear = false;
    public GameObject clearCanvas;
    // Start is called before the first frame update
    void Start()
    {
        clearCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time > 96)
        if(!AudioManager._audioSource.isPlaying)
        {
            clearCanvas.SetActive(true);

        }
        else
        {
            clearCanvas.SetActive(false);
        }
    }
}
