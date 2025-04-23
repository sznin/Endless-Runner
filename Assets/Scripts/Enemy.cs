using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        enemyRB.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        enemyRB.velocity = Vector2.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Bullet")
        {
            gameObject.SetActive(false);
            Destroy(other.gameObject);
            Debug.Log("you got hit!!")
        }
    }
}
