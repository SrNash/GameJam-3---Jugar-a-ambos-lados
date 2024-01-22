using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{    
    public static PlayerLife instance;

    [Header("Vida")]
    [SerializeField] int maxLife;    
    [SerializeField] int currentLife;

    [Header("Intentos")]
    [SerializeField] int startTries;
    [SerializeField] int maxTries;
    [SerializeField] int currentTries;

    [Header("Invencibilidad")]
    [SerializeField] float timeInvincible;
    [SerializeField] bool isInvincible;
    [SerializeField] float invincibleTimer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        currentLife = maxLife;
        maxTries = startTries;
        currentTries = startTries;
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }           

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeLife(-1);
        }
    }

    public void ChangeLife(int amount)
    {        
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        //sonido
        currentLife += amount;
        CheckLife();
    }

    public void ChangeTries(int amount)
    {
        currentTries += amount;
        CheckTries();
    }

    private void CheckLife()
    {
        if (currentLife == 0)
        {
            ChangeTries(-1);
            //Resetear nivel
            currentLife = maxLife;
            Debug.Log("ResetLevel");
        }
    }

    private void CheckTries()
    {
        if (currentTries == 0)
        {
            //Añadir fin del juego
            Debug.Log("GameOver");
        } 
    }
}
