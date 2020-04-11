using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SettingsData
{
    public int playerMaxHealth;
    public int playerDamage;
    public float playerAttackRate;
    public int playerSpeed;

    public int enemyHealth;
    public int enemyDamage;
    public int enemyReward;
    public float enemyAttackRate;

    public int fruitHealth;
    public int gemPoints;

    public SettingsData()
    {
        if (File.Exists(PathManager.settingsPath))
        {
            SettingsData data = SaveSystem.Load<SettingsData>();

            playerMaxHealth = data.playerMaxHealth;
            playerDamage = data.playerDamage;
            playerAttackRate = data.playerAttackRate;
            playerSpeed = data.playerSpeed;

            enemyHealth = data.enemyHealth;
            enemyDamage = data.enemyDamage;
            enemyReward = data.enemyReward;
            enemyAttackRate = data.enemyAttackRate;

            fruitHealth = data.fruitHealth;
            gemPoints = data.gemPoints;

        } else
        {
            resetToDefaultValues();
        }
    }

    public void resetToDefaultValues()
    {
        Player player = new Player();
        playerMaxHealth = player.maxHealth;

        Weapon weapon = new Weapon();
        playerAttackRate = weapon.attackRate;
        playerDamage = Weapon.damage;

        PlayerMovement playerMovement = new PlayerMovement();
        playerSpeed = (int)playerMovement.runSpeed;

        Enemy enemy = new Enemy();
        enemyHealth = enemy.health;
        enemyDamage = enemy.enemyDamage;
        enemyReward = enemy.enemyDeathReward;
        enemyAttackRate = enemy.attackRate;

        Cherry cherry = new Cherry();
        fruitHealth = cherry.healthValue;

        Gem gem = new Gem();
        gemPoints = gem.gemReward;
    }
}
