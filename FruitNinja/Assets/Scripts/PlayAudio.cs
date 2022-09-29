using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    //awakes certain child objects when it is suppose to
    public Collider bladeCol;
    public AudioSource GameStart;
    public AudioSource GameOver;
    public AudioSource GameSwipe;
    public AudioSource GameSizzle;


    public AudioSource AppleCut;
    public AudioSource KiwiCut;
    public AudioSource OrangeCut;
    public AudioSource LemonCut;
    public AudioSource WatermelonCut;
    // public AudioSource BlueberryCut;



    private bool running;
 
    void Start()
    {
        // End(false);
        // Start(false);

        Start(true);
    }   

    public void Start(bool tf)
    {
        // GameStart.SetActive(tf);
        GameStart.Play();
    }

    public void End(bool tf)
    {
        //activated from bomb script
        // GameOver.SetActive(tf);
        GameOver.Play();
    }

    public void Swipe(bool tf)
    {
    
        // GameSwipe.SetActive(tf);
        GameSwipe.Play();
        Wait(10);
        // GameSwipe.SetActive(false);
        // GameSwipe.Play();

    }

    //need to figure out a way to have multiple instances of this audio
    public void Sizzle(bool tf)
    {
        print("swipe");
        // //activated from spawner script
        // GameSizzle.SetActive(true);
        // if (FindObjectOfType<Bomb>() != true)
        // {
        //     GameSizzle.SetActive(false);
        // }
        GameSizzle.Play();
        // if (tf == true){
        //     GameSizzle.SetActive(true);
        // } else {
        //     GameSizzle.SetActive(false);
        // }

    }

    /*
     public void fruitLaunchNoise()
    {

    }
     */

    public void fruitCut(string fruit){
      
        switch(fruit){
            case string a when a.Contains("Apple"): AppleCut.Play(); break;
 
            case string b when b.Contains("Kiwi"): KiwiCut.Play(); break;

            case string c when c.Contains("Orange"): OrangeCut.Play(); break;

            case string d when d.Contains("Lemon"): LemonCut.Play(); break;

            case string e when e.Contains("Watermelon"): WatermelonCut.Play(); break;


            default: break;

        }
    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }


}
