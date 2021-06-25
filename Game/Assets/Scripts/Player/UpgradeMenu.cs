using System.Collections;
 using System.Collections.Generic;
 using System;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class UpgradeMenu : MonoBehaviour {
     [SerializeField]
     private Text healthText;
 
     [SerializeField]
     private Text speedText;
 
     [SerializeField]
     private Text damageText;
 
     [SerializeField]
     private float healthMultiplier = 1.3f;
 
     [SerializeField]
     private float speedMultiplier = 1.3f;
 
     [SerializeField]
     private float damageMultiplier = 1.2f;
 
     [SerializeField]
     private int upgradeCost = 30;
 
     private Weapon udamage;
     private PlayerStats stats;
 
 
     public GameObject pistol = new GameObject("pistol");
 
     void OnEnable() {
         stats = PlayerStats.instance;
         udamage = Weapon.instance;
         UpdateValues();
     }
 
     void UpdateValues() {
         healthText.text = "HEALTH: " + stats.maxHealth.ToString();
         speedText.text = "SPEED: " + stats.movementSpeed.ToString();
         damageText.text = "DAMAGE: " + udamage.Damage.ToString();
 
     }
 
     public void UpgradeHealth() {
 
         if (GameMaster.Money < upgradeCost)
             return;
 
         stats.maxHealth = (int)(stats.maxHealth * healthMultiplier);
         GameMaster.Money -= upgradeCost;
         UpdateValues();
     }
 
     public void UpgradeSpeed() {
 
         if (GameMaster.Money < upgradeCost)
             return;
 
         stats.movementSpeed = (int)(stats.movementSpeed * speedMultiplier);
         GameMaster.Money -= upgradeCost;
         UpdateValues();
     }
 
     public void UpgradeDamage() {
     pistol.SetActive(true);
         //set pistol gameobject to be true but make the damage set to zero after hitting U
     //GetComponent<Enemy>(DamageEnemy.damage).enabled = !active;
         if (GameMaster.Money < upgradeCost)
             return;
 
         udamage.Damage = (int)(udamage.Damage * damageMultiplier);
         GameMaster.Money -= upgradeCost;
         UpdateValues();
     }
 }