using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {

        var id = collider?.attachedRigidbody.GetComponent<Identifier>();
        if (id == null) return;

        if(id.Identity == Identity.Player)
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
}
