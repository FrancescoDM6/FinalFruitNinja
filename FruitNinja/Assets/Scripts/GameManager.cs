using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Animator scoreanimator;
    public Image fadeImage;

    private Blade blade;
    private Spawner spawner;

    public int score;
    public bool bonus;
    public float timer = 10f;
    public int multiplier;
  


    private void Update ()
    {
        if (bonus)
        {
            if (timer > 0)
            {
                print("1");
                timer -= Time.deltaTime;
                print('2');
            } else {
                bonus = false;
                multiplier = 1;
                timer = 10f;
            }
        }
    }

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
        
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        multiplier = 1;
        scoreText.text = score.ToString();
        
        bonus = false;

        ClearScene();
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();
        foreach(Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }

        /*Blueberry[] bbs = FindObjectsOfType<Blueberry>();
        foreach (Blueberry blueberry in bbs)
        {
            Destroy(blueberry.gameObject);*/

    }

    public void IncreaseScore(int amount, int mult)
    {
        if (mult > 1)
        {
            bonus = true;
            multiplier = mult;
        }
        score += (amount*multiplier);
        scoreanimator.SetTrigger("change");

        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;
        
        StartCoroutine(ExplodeSequence());
    }

    public IEnumerator ExplodeSequence()
    {
        MainManager.Instance.score = score;

        float elapsed = 0f;
        float duration = 1.5f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;
            
            yield return null;
        }

        yield return new WaitForSecondsRealtime(2.8f);
        SceneManager.LoadScene(1);

    }

   
}
