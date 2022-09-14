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
    public float timer = 8f;
    public float time;

    public GameObject splashScreen;
    public GameObject intro;

    //public bool awake;

    //public Image fadeImage;


    void Start()
    {
        //Camera.main.fieldOfView = fov;
       // awake = true;
        //Zoom(awake);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (fov <= 170)
        {
            Camera.main.fieldOfView = fov;
            fov += changeMultiplier;
        }
        else if (time > timer)
        {
            intro.SetActive(false);
            splashScreen.SetActive(true);
            //awake = false;
            //Fade();
        }
    }

    //I wanted to make it fade out before changing but I need mroe time to figure it out
   
    /*
    public IEnumerator Fade()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);


        elapsed = 0f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        SceneManager.LoadScene(0);

    }*/
}
