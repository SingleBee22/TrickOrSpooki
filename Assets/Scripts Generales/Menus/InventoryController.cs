using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public TextMeshProUGUI batteryText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI keyText;

    private int batteryCount = 0;
    private int score = 0;
    private int keyCount = 0;

    private void Start()
    {
        UpdateBatteryUI();

        UpdateScoreUI();
        UpdateKeyUI();
    }

    public void AddBattery()
    {
        batteryCount++;
        UpdateBatteryUI();
    }

    public void UseBattery()
    {
        batteryCount--;
        UpdateBatteryUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public void AddKey()
    {
        keyCount++;
        UpdateKeyUI();
    }

    public void UseKey()
    {
        keyCount--;
        UpdateKeyUI();
    }

    public int GetKeyCount()
    {
        return keyCount;
    }

    private void UpdateBatteryUI()
    {
        batteryText.text = "" + batteryCount.ToString();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "" + score.ToString();
    }

    private void UpdateKeyUI()
    {
        keyText.text = "" + keyCount.ToString();
    }
}
