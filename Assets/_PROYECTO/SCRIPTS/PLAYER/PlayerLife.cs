using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    #region INSTANCE
    public static PlayerLife instance;
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
    #endregion

    #region VARIABLES
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
    #endregion

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
            //añadir parpadeo??
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }          
        }
    }

    public void ResetLevel()
    {
        //Resetear nivel
        currentLife = maxLife;
        Debug.Log("ResetLevel");
    }

    #region VIDA
    public void ChangeLife(int amount)
    {        
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        //añadir efecto daño
        //sonido
        currentLife += amount;
        CheckLife();
    }

    private void CheckLife()
    {
        if (currentLife == 0)
        {
            ChangeTries(-1);
            ResetLevel();            
        }
    }
    #endregion
    #region INTENTOS
    public void ChangeTries(int amount)
    {
        currentTries += amount;
        CheckTries();
    }    

    private void CheckTries()
    {
        if (currentTries == 0)
        {
            //Añadir fin del juego
            Debug.Log("GameOver");
        }

        if(currentTries > maxTries)
        {
            currentTries = maxTries;
        }
    }
    #endregion
}
