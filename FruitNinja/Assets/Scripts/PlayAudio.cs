using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    //awakes certain child objects when it is suppose to
    public Collider bladeCol;
    public GameObject GameStart;
    public GameObject GameOver;
    public GameObject GameSwipe;
    public GameObject GameSizzle;

    private bool running;

    void Start()
    {
        End(false);
        Start(false);

        Start(true);
    }   

    public void Start(bool tf)
    {
        GameStart.SetActive(tf);
    }

    public void End(bool tf)
    {
        //activated from bomb script
        GameOver.SetActive(tf);
    }

    public void Swipe(bool tf)
    {
    
        GameSwipe.SetActive(tf);
        Wait(2);
        GameSwipe.SetActive(false);

    }

    //need to figure out a way to have multiple instances of this audio
    public void Sizzle(bool tf)
    {
        print("swipe");
        //activated from spawner script
        GameSizzle.SetActive(tf);
        if (GameObject.Find("Bomb") != null)
        {
            GameSizzle.SetActive(false);
        }

    }

    /*
     public void fruitLaunchNoise()
    {

    }
     */

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }


}
