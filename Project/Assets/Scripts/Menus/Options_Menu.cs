using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options_Menu : MonoBehaviour
{
    public Slider playerMaxHealthSlider;
    public Slider playerDamageSlider;
    public Slider playerAttackRateSlider;
    public Slider playerSpeedSlider;

    public Slider enemyHealthSlider;
    public Slider enemyDamageSlider;
    public Slider enemyAttackRateSlider;
    public Slider enemyDeathRewardSlider;

    public Slider fruitHealthSlider;
    public Slider gemPointsSlider;

    private void Start()
    {
        LoadSettings(false);
    }

    public void Back()
    {
        SaveSettings();
        SceneManager.LoadScene("MainMenu");
    }

    private void LoadSettings(bool ignoreSavedData)
    {
        SettingsData data = new SettingsData();
        if (ignoreSavedData) data.resetToDefaultValues();

        playerMaxHealthSlider.value = data.playerMaxHealth;
        playerDamageSlider.value = data.playerDamage;
        playerAttackRateSlider.value = data.playerAttackRate;
        playerSpeedSlider.value = data.playerSpeed;

        enemyHealthSlider.value = data.enemyHealth;
        enemyDamageSlider.value = data.enemyDamage;
        enemyAttackRateSlider.value = data.enemyAttackRate;
        enemyDeathRewardSlider.value = data.enemyReward;

        fruitHealthSlider.value = data.fruitHealth;
        gemPointsSlider.value = data.gemPoints;
    }

    private void SaveSettings()
    {
        SettingsData data = new SettingsData();

        data.playerMaxHealth = (int) playerMaxHealthSlider.value;
        data.playerDamage = (int) playerDamageSlider.value;
        data.playerAttackRate = playerAttackRateSlider.value;
        data.playerSpeed = (int) playerSpeedSlider.value;

        data.enemyHealth = (int) enemyHealthSlider.value;
        data.enemyDamage = (int) enemyDamageSlider.value;
        data.enemyAttackRate = enemyAttackRateSlider.value;
        data.enemyReward = (int) enemyDeathRewardSlider.value;

        data.fruitHealth = (int) fruitHealthSlider.value;
        data.gemPoints = (int) gemPointsSlider.value;

        SaveSystem.Save(data);
    }

    public void RestoreDefaultData()
    {
        LoadSettings(true);
        if (File.Exists(PathManager.settingsPath))
        {
            File.Delete(PathManager.settingsPath);
        }
    }
}
