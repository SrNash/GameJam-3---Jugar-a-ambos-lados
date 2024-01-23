using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float gravity;
    [SerializeField] float speed;
    [SerializeField] GameObject humo;
    bool isRotating;
    bool isTop;
    bool isBot;
    private void Start()
    {
        isRotating = false;
        isTop = false;
        isBot = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(humo, transform.position, transform.rotation);
            gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
            //transform.Rotate(0, 0, 180);
            isRotating = true;
            isTop = !isTop;
            isBot = !isBot;
        }

        if (isRotating)
        {
            if (isBot) 
            {
                Debug.Log("isBot");
                transform.Rotate(0, 0, -speed * Time.deltaTime);
                if (transform.rotation.eulerAngles.z <= 10)
                {
                    isRotating = false;
                    transform.Rotate(0, 0, 0);                    
                }
            } 
            else
            {
                Debug.Log("isTop");
                transform.Rotate(0, 0, speed * Time.deltaTime);
                if (transform.rotation.eulerAngles.z >= 180)
                {
                    isRotating = false;
                    transform.Rotate(0, 0, 0);                    
                }
            }
            
        }
    }
}
