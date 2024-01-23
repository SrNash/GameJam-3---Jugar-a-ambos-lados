using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [Header("Test")]
    [SerializeField] TextMeshProUGUI triesText;

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

    [SerializeField] SpriteRenderer spriteRend;
    Animator animator;
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        currentLife = maxLife;
        currentTries = startTries;
        triesText.SetText("Tries: " + currentTries);
    }

    void Update()
    {
        if (isInvincible)
        {
            animator.SetBool("IsDamaged", true);
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                animator.SetBool("IsDamaged", false);
            }          
        }
    }

    //Quitar cuando est�n los obstaculos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeLife(-1);
        }
    }

    private void ResetLevel()
    {
        //hacer una pausa antes de reinciarlo
        //desactivar poder darle al espacio en ese tiempo
        animator.SetBool("IsDead", false);
        //Resetear nivel
        currentLife = maxLife;
        Debug.Log("ResetLevel");
    }

    private void GameOver()
    {        
        //A�adir fin del juego
        Debug.Log("GameOver");
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
            Debug.Log("Nami");
            animator.SetBool("IsDead", true);
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
            GameOver();   
        }

        if(currentTries > maxTries)
        {
            currentTries = maxTries;
        }
        triesText.SetText("Tries: " + currentTries);
    }
    #endregion
}
