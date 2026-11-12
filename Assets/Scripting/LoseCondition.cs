using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public static LoseCondition Instance;
    public int currentScore = 0;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private GameObject LoseScreenUI; //drag the ui panel onto this thing

    private bool hasLost = false; //check if you lost

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateUI();
        if (LoseScreenUI != null)
        {
            LoseScreenUI.SetActive(false); // hides at start
        }
    }
    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
        {
            if (hasLost) return; //no more score updates if you lose

            if (currentScore < 0)
            {
                TriggerLose();
            }
        }
    }
    private void TriggerLose()
    {
        hasLost = true;
        Debug.Log("whatevertexthereorsmthn boohoo you lost frown emoji");
        if (LoseScreenUI != null)
        {
            LoseScreenUI.SetActive(true); // show the lose screen ui
        }
    }
    public void ResetScore()
    {
        currentScore = 0;
        hasLost = false; //redo lose condition
        UpdateUI();
        if (LoseScreenUI != null)
        {
            LoseScreenUI.SetActive(false); // hide the lose screen ui

        }
    }
        private void UpdateUI()
    {
        if (scoretext != null)
        {
            scoretext.text = "Score: " + currentScore;
        }
    }
}