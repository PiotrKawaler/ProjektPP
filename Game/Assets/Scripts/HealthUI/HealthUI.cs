using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthUI : MonoBehaviour
{


    [Header("Prefabs")]
    [SerializeField] GameObject heartIcon;

    [Header("Transforms")]
    [SerializeField] Transform conteinerParent = null;


    [Header("Refrences")]
    [SerializeField] PlayerHealth playerHealth;





    void onHealthChanged(int newValue)
    {

        int i = 0;
        foreach (Transform child in conteinerParent)
        {
            var container = child.GetComponent<HeartContainerUI>();

            if (container != null)
            {
                container.setFilled(i < newValue);
                i++;
            }

        }
    }


    private void clearContainers()
    {
        if (conteinerParent == null) return;
        while (conteinerParent.childCount > 0)
        {
            Transform child =conteinerParent.GetChild(0);
            child.parent = null;
            Destroy(child.gameObject);
        }
    }

    private void buildContainers(int count)
    {
        if (conteinerParent == null)
        {
            Debug.LogWarning("Asign container parent");
            return;
        }
        clearContainers();
        for (int i = 0; i < count; i++)
        {
            Instantiate(heartIcon, conteinerParent);
        }

    }
    private void onMaxHealthChanged(int newMaxHealth)
    {
        buildContainers(newMaxHealth);
        onHealthChanged(playerHealth.CurrentHealth);
    }



    private void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        if (playerHealth != null)
        {

            playerHealth.MaxHealthChangedEvent += onMaxHealthChanged;
            onMaxHealthChanged(playerHealth.MaxHealth);

            playerHealth.HealthChangedEvent += onHealthChanged;
            onHealthChanged(playerHealth.CurrentHealth);


        }

    }



}
