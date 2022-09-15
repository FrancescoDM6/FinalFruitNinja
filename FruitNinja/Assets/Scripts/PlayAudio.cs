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
        //activated from blade script

        /*need to figure out how to make it play
         when mouse is pressed but also turn off
        when audio is done playing and also
        figure out how to have it play everytime
        mouse is moved*/
        GameSwipe.SetActive(tf);

    }

    //need to figure out a way to have multiple instances of this audio
    public void Sizzle(bool tf)
    {
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
