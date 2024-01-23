using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public float _frameRate;
    public GameObject _gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = (int)_frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        { instance = this; }

        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        _gameOverScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("ObstaclesScene");
    }

    public void BackToMainmenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
