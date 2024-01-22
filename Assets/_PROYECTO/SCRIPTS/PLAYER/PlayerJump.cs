using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float gravity;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }
}
