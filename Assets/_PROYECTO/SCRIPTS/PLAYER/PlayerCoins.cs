using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;

    [SerializeField] private int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Instantiate(particlePrefab);
        }
    }
}
