using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // public void MoveToScene(int sceneID)
    // {
    //     print("changed");
    //    SceneManager.LoadScene(sceneID);
    // }

    public void ToMenu (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
