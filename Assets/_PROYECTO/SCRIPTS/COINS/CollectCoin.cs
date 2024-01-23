using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VictorRivero;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] int coinPoints;
    [SerializeField] Vector3 offset;
    public Vector3 Offset { get { return offset; } set {  offset = value; } }   //En caso de querer instanciar las
                                                                                //monedas para reubicar la aparición 
                                                                                //de los numeros flotantes

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Animator>().SetTrigger("TakeCoin");
            ScoreManager.Instance.AddPointsToScore(coinPoints);

            GameObject _point = ObjectPool.Instance.GetPooledNumber();

            if (_point != null)
            {
                gameObject.SetActive(false);
                _point.GetComponentInChildren<TextMeshProUGUI>().text = "+" + coinPoints.ToString();
                _point.SetActive(true);
                _point.transform.position = transform.position + offset;
            }
        }   
    }
}
