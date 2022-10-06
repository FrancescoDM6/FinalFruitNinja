using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTimer : MonoBehaviour
{
    public int countTime;
    private Transform barSize;
    public bool isFlipped;
    public GameObject playerCam;

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
            if (countTime % 59 == 0)
            {
                if (isFlipped)
                    Normal();
                else
                    Flip();

            }
            barSize.localScale -= new Vector3(1, 0, 0);
            countTime++;
            yield return new WaitForSeconds(1);
        }
    }

    public void Normal()
    {
        //playerCam.Transform.Rotate += Quaternion.Euler(0f, -180f, 0f);
        isFlipped = false;
    }

    public void Flip()
    {
        //playerCam.Transform.Rotate += Quaternion.Euler(0f, 180f, 0f);
        isFlipped = true;
    }
}
