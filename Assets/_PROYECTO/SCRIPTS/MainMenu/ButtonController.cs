using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject optionsMenu;
    public Animator optionsMenuAnimator;
    private string Menu_Opening, Menu_Closing;


    void Start()
    {
        optionsMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
        optionsMenuAnimator.Play("Menu_Opening");
    }

    public void CloseOptionsMenuAnimation()
    {
        optionsMenuAnimator.Play("Menu_Closing");
        optionsMenuAnimator.SetBool("Closed", true);
        Invoke("CloseOptionsMenu", 0.10f);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

}
