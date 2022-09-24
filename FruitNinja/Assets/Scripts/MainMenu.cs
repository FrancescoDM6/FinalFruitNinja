using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public TMP_Text highscore;

    public int hscore;
    public int score;

    
    
    


    public void PlayGame (){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OrigBuild (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    void Update(){

        if (MainManager.Instance != null){
            score = MainManager.Instance.hiscore;

            if (score > hscore){
                highscore.text = score.ToString();
                hscore = score;
            }
        }


        // if (GameManager.gameo != null){
        //     go = GameManager.gameo.gover;

        // }
        
        // if(go == true){
        //     gameover.SetActive(true);
        // } else {
        //     gameover.SetActive(false);
        // }
    }

    // public void HighScore(){
        
    // }
    
    
}
