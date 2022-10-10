using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBlade : MonoBehaviour
{
    public static float bladeNum = 1f;

   
    public void setBladeNum(float num)
    {
        bladeNum = num;
        print(bladeNum);
    }
    public float getBladeNum()
    {
        print(bladeNum);
        return bladeNum;
    }


}
