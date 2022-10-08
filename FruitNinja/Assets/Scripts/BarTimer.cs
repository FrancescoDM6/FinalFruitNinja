using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTimer : MonoBehaviour
{
    public int countTime;
    private Transform barSize;
    public bool isFlipped;
    // public GameObject playerCam;

    public void Start()
    {
        countTime = 1;
        isFlipped = false;
        barSize = GetComponent<Transform>();
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        while (true)
        {
            if (countTime % 45   == 0)
            {
                if (isFlipped)
                    Normal();
                else
                    Flip();

            }

            if (!isFlipped)
            { 
                barSize.localScale -= new Vector3(1, 0, 0);

            } else {
                barSize.localScale += new Vector3(1, 0, 0);

            }

            countTime++;
            yield return new WaitForSeconds(1);
        }
    }

    public void Normal()
    {

        FindObjectOfType<CameraEffect>().Flip(true);
        // playerCam.transform.rotation *= Quaternion.Euler(180, 0, 0);

        isFlipped = false;
    }

    public void Flip()
    {

        FindObjectOfType<CameraEffect>().Flip(true);
        // playerCam.transform.rotation *= Quaternion.Euler(180, 0, 0);
        isFlipped = true;
    }
}
