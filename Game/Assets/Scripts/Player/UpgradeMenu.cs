// using System.Collections;
//  using System.Collections.Generic;
//  using System;
//  using UnityEngine;
//  using UnityEngine.UI;
 
//  public class UpgradeMenu : MonoBehaviour {
//      [SerializeField]
//      private Text healthText;
 
//      [SerializeField]
//      private Text speedText;
 
//      [SerializeField]
//      private Text damageText;
 
//      [SerializeField]
//      private float healthMultiplier = 1.3f;
 
//      [SerializeField]
//      private float speedMultiplier = 1.3f;
 
//      [SerializeField]
//      private float damageMultiplier = 1.2f;
 
//      [SerializeField]
//      private int upgradeCost = 10;
 
//      private PlayerStats stats;

//      void OnEnable() {
//          stats = PlayerStats.instance;
//          UpdateValues();
//      }
 
//      void UpdateValues() {
//          healthText.text = "HEALTH: " + stats.maxHealth.ToString();
//          speedText.text = "SPEED: " + stats.movementSpeed.ToString();
//          damageText.text = "DAMAGE: " + udamage.Damage.ToString();
 
//      }
 
//      public void UpgradeHealth() {
 
//          UpdateValues();         
//      }
 
//      public void UpgradeSpeed() {
 
//          UpdateValues();         
//      }
 
//      public void UpgradeDamage() {
     
//          UpdateValues();
//      }
//  }