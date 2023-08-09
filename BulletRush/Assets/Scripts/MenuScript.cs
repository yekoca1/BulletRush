using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //public MyGameManager mygamemanager;
    private int Level;
    private void Start()
    {
        //mygamemanager = GameObject.FindObjectOfType<MyGameManager>();
    }

    public void play()
    {
        SceneManager.LoadScene(1); // Yeni sahneyi yükle
        ResetCurrentLevel();
    }

    public void quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ResetCurrentLevel()
    {
        PlayerPrefs.SetInt("currentLevel", 1); // currentLevel'ı sıfırla veya istediğiniz başka bir değerle güncelle
    }
}
