using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Toca");
            Instantiate(particles, other.transform.position, other.transform.rotation);

            Destroy(gameObject);
        }
    }
}
