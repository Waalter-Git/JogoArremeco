using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private IEnumerator FadeIn()
    {
        fadeImage.color = new Color(0, 0, 0, 1);
        float timer = 0;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, 1 - timer / fadeDuration);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        float timer = 0;
        fadeImage.color = new Color(0, 0, 0, 0);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, timer / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
