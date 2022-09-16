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

    public void Start(){
    Camera.main.fieldOfView = fov;
    }

  public void Update(){
      if (fov < endFOV)
        {
        Camera.main.fieldOfView = fov;
        fov += changeMultiplier;
        }
        else
        {
        StartCoroutine(Fade());
        }
  }

   
    
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
