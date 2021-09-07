using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        ScoreTextScript.coinCount++;
        var colider = GetComponent<Collider2D>();
        if (colider != null)
        {
            colider.enabled = false;
        }
        Destroy(gameObject);
    }
}
