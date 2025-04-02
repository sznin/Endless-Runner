using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int pointValue = 10;
    public void Collected()
    {
        GameManager.Instance.currentCollected++;
        GameManager.Instance.currentScore += pointValue;
        Destroy(gameObject);
    }
}
