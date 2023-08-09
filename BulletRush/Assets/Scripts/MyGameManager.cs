using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;
using TMPro;




public class MyGameManager : MonoBehaviour
{
    public string nextLevelName;
    public TextMeshProUGUI levelText;

    private int currentLevel = 1;

    public GameObject nextButton;
    public GameObject restartButton;
    public GameObject quitButton;
    private void Start()
    {
        // PlayerPrefs'tan currentLevel değişkeninin değerini okuyun
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);

        nextButton = GameObject.Find("Next");
        restartButton = GameObject.Find("Restart");
        quitButton = GameObject.Find("Quit");
        levelText = GameObject.Find("levelText").GetComponent<TextMeshProUGUI>();

        UpdateLevelText();
        nextButton.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void nextLevel()
    {
        currentLevel++;
        UpdateLevelText();

        // PlayerPrefs'ta currentLevel değişkeninin değerini güncelleyin
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1;
        //GameMonetize.Instance.ShowAd();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        //GameMonetize.Instance.ShowAd();
    }

    public void quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Death()
    {
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        Time.timeScale = 0;
    }
    public void Win()
    {
        nextButton.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        Time.timeScale = 0;
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }

    /*public void Lose()
    {
        Time.timeScale = 0;
        restartButton.SetActive(true);
        quitButton.SetActive(true);

    }*/

}
