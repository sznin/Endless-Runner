using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Happened");

        if (collision.transform.tag == "Obstacle")
        {
            Debug.Log("Collision with obstacle");
            gameObject.SetActive(false);
        }

        if (collision.GetComponent<Collectable>() == true)
        {
            collision.GetComponent<Collectable>().Collected();
        }
    }


}
