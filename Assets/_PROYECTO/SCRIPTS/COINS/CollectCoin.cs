using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VictorRivero;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] int coinPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Animator>().SetTrigger("TakeCoin");
            ScoreManager.Instance.AddPointsToScore(coinPoints);
            Destroy(gameObject, 0.1f);
        }   
    }
}
