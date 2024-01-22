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
    [SerializeField] int numberOfFlashes;
    SpriteRenderer spriteRend;
    #endregion

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
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
            StartCoroutine(ChangeColor());
        }
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

    private IEnumerator ChangeColor()
    {
        for(int i=0; i<numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(timeInvincible / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(timeInvincible / (numberOfFlashes * 2));
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
