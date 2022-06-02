using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicObjeto : MonoBehaviour
{
    bool activaClick = false;
    float grados = 30f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (activaClick)
        {
            transform.Rotate(Time.deltaTime * grados, 0, 0); 
        }
    }

    private void OnMouseDown()
    {
        if (activaClick)
        {
            activaClick = false;
        }

        else
        {
            activaClick = true;
        }
    }
}
