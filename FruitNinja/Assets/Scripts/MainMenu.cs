using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject gameover;

    private bool gover;
    
    


    public void PlayGame (){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OrigBuild (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    void Awake(){
        if (GameManager.gameo != null){
            gover = GameManager.gameo.gover;

        }
        
        if(gover== true){
            gameover.SetActive(true);
        } else {
            gameover.SetActive(false);
        }
    }
}
