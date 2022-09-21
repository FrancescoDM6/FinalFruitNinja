using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_OLD : MonoBehaviour
{
    public TMP_Text scoreText;
    public Image fadeImage;

    private Blade_OLD blade;
    private Spawner_OLD spawner;

    public int score;

    private void Awake()
    {
        blade = FindObjectOfType<Blade_OLD>();
        spawner = FindObjectOfType<Spawner_OLD>();
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
        scoreText.text = score.ToString();

        ClearScene();
    }

    private void ClearScene()
    {
        Fruit_OLD[] fruits = FindObjectsOfType<Fruit_OLD>();
        foreach(Fruit_OLD fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb_OLD[] bombs = FindObjectsOfType<Bomb_OLD>();
        foreach (Bomb_OLD bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }

        /*Blueberry[] bbs = FindObjectsOfType<Blueberry>();
        foreach (Blueberry blueberry in bbs)
        {
            Destroy(blueberry.gameObject);*/

    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
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

        SceneManager.LoadScene(1);

        /*NewGame();

        elapsed = 0f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }*/

    }
}
