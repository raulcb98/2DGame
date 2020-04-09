using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options_Menu : MonoBehaviour
{
    public Slider enemyHealthSlider;
    public Slider enemyDamageSlider;

    private void Start()
    {
        LoadSettings();
    }

    public void Back()
    {
        SaveSettings();
        SceneManager.LoadScene("MainMenu");
    }

    private void LoadSettings()
    {
        SettingsData data = new SettingsData();
        enemyHealthSlider.value = data.enemyHealth;
        enemyDamageSlider.value = data.enemyDamage;
    }

    private void SaveSettings()
    {
        SettingsData data = new SettingsData();
        data.enemyHealth = (int) enemyHealthSlider.value;
        data.enemyDamage = (int) enemyDamageSlider.value;
        SaveSystem.Save(data);
    }

    public void RestoreDefaultData()
    {
        Enemy enemy = new Enemy();
        enemyHealthSlider.value = enemy.health;
        enemyDamageSlider.value = enemy.enemyDamage;
    }
}
