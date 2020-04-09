using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SettingsData
{
    public int enemyHealth;
    public int enemyDamage;

    public SettingsData()
    {
        if (File.Exists(PathManager.settingsPath))
        {
            SettingsData data = SaveSystem.Load<SettingsData>();
            enemyHealth = data.enemyHealth;
            enemyDamage = data.enemyDamage;
        } else
        {
            Enemy enemy = new Enemy();
            enemyHealth = enemy.health;
            enemyDamage = enemy.enemyDamage;
        }
    }
}
