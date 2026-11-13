using TMPro;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private GameObject diceObject1;
    [SerializeField] private GameObject diceObject2;

    [SerializeField] private Rigidbody diceRigid1;
    [SerializeField] private Rigidbody diceRigid2;

    private Vector3 dicePos1;
    private Vector3 dicePos2;   

    [SerializeField] private int betAmount;
    private int betTotal = 0;

    [SerializeField] private float randomForce;
    [SerializeField] private float randomTorque;

    [SerializeField] private MoneyandWinLoseConditions moneyScript;

    [SerializeField] private TextMeshProUGUI betText;

    private bool hasBet = false;
    private bool hasRolled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grabbing money script
        MoneyandWinLoseConditions[] tempArray = FindObjectsOfType(typeof(MoneyandWinLoseConditions)) as MoneyandWinLoseConditions[];
        moneyScript = tempArray[0];

        dicePos1 = diceObject1.transform.position;
        dicePos2 = diceObject2.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        betText.text = "Bet Amount: $" + betTotal;

        if (hasBet)
        {
            if (diceRigid1.linearVelocity.magnitude > 0.0025f || diceRigid2.linearVelocity.magnitude > 0.0025f)
            {
                hasRolled = true;
            }

            if (diceRigid1.linearVelocity.magnitude < 0.0025f && diceRigid2.linearVelocity.magnitude < 0.0025f && hasRolled)
            {
                hasBet = false;

                int diceNum1 = GetDiceNum(diceObject1.transform);
                int diceNum2 = GetDiceNum(diceObject2.transform);

                Debug.Log("Dice 1: " + diceNum1);
                Debug.Log("Dice 2: " + diceNum2);

                if (Mathf.Abs(diceNum1 - diceNum2) < 2)
                {
                    moneyScript.ChangeMoney(-betTotal * 2);
                }
                else
                {
                    moneyScript.ChangeMoney(betTotal);
                }

                hasRolled = false;
            }
        }
    }

    int GetDiceNum(Transform dice)
    {

        float[] diceAngles = new float[6];
        diceAngles[4] = Vector3.Angle(dice.transform.up, Vector3.up); //
        diceAngles[2] = Vector3.Angle(-dice.transform.up, Vector3.up); //
        diceAngles[1] = Vector3.Angle(dice.transform.right, Vector3.up);
        diceAngles[3] = Vector3.Angle(-dice.transform.right, Vector3.up); //
        diceAngles[0] = Vector3.Angle(dice.transform.forward, Vector3.up);
        diceAngles[5] = Vector3.Angle(-dice.transform.forward, Vector3.up); //

        float smallestAngle = 100000.0f;
        int   smallestInt = 0;

        for (int i = 0; i < 6; i++)
        {
            if (smallestAngle > diceAngles[i])
            {
                smallestAngle = diceAngles[i];
                smallestInt = i;
            }
        }

        return smallestInt + 1;
    }

    public void IncreaseBet()
    {
        if (moneyScript.money > betTotal && !hasBet)
        {
            betTotal += betAmount;
            Debug.Log("Bet Increased!");
        }
    }

    public void DecreaseBet()
    {
        if (betTotal > 0 && !hasBet)
        {
            betTotal -= betAmount;
            Debug.Log("Bet Decreased!");
        }

    }

    public void Bet()
    {
        if (!hasBet)
        {
            diceRigid1.isKinematic = false;
            diceRigid2.isKinematic = false;

            Vector3 forceRand = new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, Random.Range(-1.0f, 1.0f)) * randomForce;
            Vector3 torqueRand = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * randomTorque;

            diceRigid1.AddForce(forceRand);
            diceRigid1.AddTorque(torqueRand);

            forceRand = new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, Random.Range(-1.0f, 1.0f)) * randomForce;
            torqueRand = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * randomTorque;

            diceRigid2.AddForce(forceRand);
            diceRigid2.AddTorque(torqueRand);

            hasBet = true;
            hasRolled = false;
        }
    }
}
