using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinAskScript : MonoBehaviour
{
    [SerializeField] private MoneyandWinLoseConditions moneyScript;
    [SerializeField] private TextMeshProUGUI moneyAmountText;

    private int moneyAmount;
    private int moneyNeeded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoneyandWinLoseConditions[] tempArray = FindObjectsByType(typeof(MoneyandWinLoseConditions)) as MoneyandWinLoseConditions[];
        moneyScript = tempArray[0];

        moneyAmount = moneyScript.money;
        moneyNeeded = 1000 - moneyAmount;

        Debug.Log("Grabbed Script: " + moneyScript);
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = "Yeah so.. you have $" + moneyAmount + ". You still need to get $" + moneyNeeded + " more to reach $1,000.";
    }
}
