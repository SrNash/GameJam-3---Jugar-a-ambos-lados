using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] int maxLife;    
    [SerializeField] int currentLife;

    [Header("Intentos")]
    [SerializeField] int startTries;
    [SerializeField] int maxTries;
    [SerializeField] int currentTries;


    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        maxTries = startTries;
        currentTries = startTries;
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SubtractHealth();
        }
    }

    public void SubtractHealth()
    {        
        currentLife--;
        Debug.Log("Vida: " + currentLife);
        CheckLife();
    }

    private void CheckLife()
    {
        if (currentLife == 0)
        {
            currentTries--;
            Debug.Log("Intentos: " + currentTries);            
            CheckTries();            
        }
    }

    private void CheckTries()
    {
        if (currentTries == 0)
        {
            //Añadir fin del juego
            Debug.Log("GameOver");
        } else
        {
            //Resetear Nivel
            currentLife = maxLife;            
            Debug.Log("ResetLevel");
            Debug.Log("Vida: " + currentLife);
        }
    }
}
