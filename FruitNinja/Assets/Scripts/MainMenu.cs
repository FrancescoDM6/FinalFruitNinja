using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
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
}
