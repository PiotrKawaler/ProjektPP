using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeShopNavigator : MonoBehaviour
{
    [SerializeField]
    private string UpgradeShopSceneName = "UpgradeShopScene";
    private bool interactionAllowed = false;


    void Update()
    {
        if (interactionAllowed && Input.GetKeyDown(KeyCode.F))
            GotoUpgradeShop();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interactionAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interactionAllowed = false;
        }
    }


    private void GotoUpgradeShop()
    {
        SceneManager.LoadScene(UpgradeShopSceneName);
    }
}
