using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    public GameObject itemPrefab;

    private bool isEmpty = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!isEmpty)
            {
                SpawnItem();
                isEmpty = true;
            }
    }


    private void SpawnItem()
    {
        GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        item.transform.localScale = transform.localScale;
    }

}
