using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    bool flip = false;

    private void Update()
    {
        while(flip == true)
        {
            transform.rotation *= Quaternion.Euler(0, 0, 180);
            flip = false;
        }
    }

    public void Flip(bool activate)
    {
        if (activate == true)
        {
            flip = true;
        } 

    }
}
