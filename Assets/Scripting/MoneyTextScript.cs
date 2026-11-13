using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyTextScript : MonoBehaviour
{
    [SerializeField] private MoneyandWinLoseConditions moneyScript; // refers to the money script; refered to in inspector
    [SerializeField] private TextMeshProUGUI moneyText; // so the text can be edited; refered in inspector

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int moneyAmount = moneyScript.money;
        moneyText.text = "Money: $" + moneyAmount;
    }
}
