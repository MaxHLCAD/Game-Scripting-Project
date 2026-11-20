using UnityEngine;
using TMPro;

public class BarCoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int totalCoins = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinUi();
        
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinText.text = "You have:" + totalCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
