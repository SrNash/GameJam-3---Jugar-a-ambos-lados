using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject optionsMenu;


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
        //Insertar animaciones al abrir el menú aquí.
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        //Insertar animaciones al cerrar el menú aquí.
    }

}
