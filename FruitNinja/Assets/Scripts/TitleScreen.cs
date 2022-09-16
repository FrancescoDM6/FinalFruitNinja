using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public float fov = 130f;
    public float changeMultiplier = .006f;
    public float endFOV;

    public Image fadeImage;


    void Start()
    {
<<<<<<< HEAD
        //Camera.main.fieldOfView = fov;
       // awake = true;
        //Zoom(awake);
        // TitleFade();
        // intro.SetActive(true);
        // splashScreen.SetActive(false);
        Zoom();
=======
        
        Camera.main.fieldOfView = fov;
>>>>>>> Hunter
    }

    void Update()
    {
<<<<<<< HEAD
        Start();
        // else if (time > timer)
        // {

            
        //     break();
            
        //     //awake = false;
        //     //Fade();
        // }
        



    }

    private void Activate(){
        intro.SetActive(false);
        splashScreen.SetActive(true);
    }

    public void Zoom(){
        if (fov <= 170) {
            Camera.main.fieldOfView = fov;
            fov += changeMultiplier;
        } else if (fov >170){
            Activate();
        }
    
    }


    //I wanted to make it fade out before changing but I need mroe time to figure it out
=======
        
        if (fov < endFOV)
        {
        Camera.main.fieldOfView = fov;
        fov += changeMultiplier;
        }
        else{
        StartCoroutine(Fade());
        }
    }

>>>>>>> Hunter
   
    
    public IEnumerator Fade()
    {
        float elapsed = 0f;
        float duration = 0.6f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(.05f);

        SceneManager.LoadScene(1);

    }
}
