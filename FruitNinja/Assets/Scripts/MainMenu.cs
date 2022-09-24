using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public TMP_Text newscore;
    public TMP_Text highscore = '0';

    public int hscore = 0;

    public GameObject gameover;
    private bool go = false;
    
    


    public void PlayGame (){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OrigBuild (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    void Update(){

        


        if (GameManager.gameo != null){
            go = GameManager.gameo.gover;

        }
        
        if(go == true){
            gameover.SetActive(true);
        } else {
            gameover.SetActive(false);
        }
    }

    public void HighScore(){
        int temp = GameManager.score;
        newscore.text = temp.ToString();

        if (temp > hscore){
            highscore.text = newscore.text;
        }
    }
}
