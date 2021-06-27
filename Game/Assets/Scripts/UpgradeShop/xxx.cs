using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UpgradeShopScript12 : MonoBehaviour
{
    public String MainSceneName = "test";

    [SerializeField]
    private Text HealthText;

    [SerializeField]
    private Text SpeedText;

    [SerializeField]
    private Text DamageText;

    [SerializeField]
    private Text CoinText;

    [SerializeField]
    private int UpgradeCost = 3;

    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = PlayerStats.MaxHealth.ToString();
        SpeedText.text = PlayerStats.MovementSpeed.ToString();
        DamageText.text = PlayerStats.Damage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = ScoreTextScript.coinCount.ToString();
    }


    public void TryUpgradeHealth()
    {
        if (TryBuyUpgrade())
            {
                PlayerStats.MaxHealth++;
                HealthText.text = PlayerStats.MaxHealth.ToString();
            }
    }


    public void TryUpgradeDamage()
    {
        if (TryBuyUpgrade())
            {
                PlayerStats.Damage++;
                DamageText.text = PlayerStats.Damage.ToString();
            }
    }


    public void TryUpgradeMovementSpeed()
    {
        if (TryBuyUpgrade())
            {
                PlayerStats.MovementSpeed++;
                SpeedText.text = PlayerStats.MovementSpeed.ToString();
            }
    }


    private bool TryBuyUpgrade()
    {
        if (ScoreTextScript.coinCount >= UpgradeCost)
        {
            ScoreTextScript.coinCount -= UpgradeCost;
            return true;
        }

        return false;
    }


    public void ExitUpgradeShop()
    {
        SceneManager.LoadScene(MainSceneName);
    }



}
