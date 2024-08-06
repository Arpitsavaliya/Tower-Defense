using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance;
	public static int Money;
	public int startMoney = 400;
    public TextMeshProUGUI GoldText;

    public static int Lives;
	public static int maxLives;
	public int startLives = 20;


	public static int Rounds;

	void Start ()
	{
		Money = startMoney;
		Lives = startLives;
		maxLives = startLives;
		GoldText.text = Money.ToString();
        Rounds = 0;
	}
	public void UpdateMoney(int currMoney)
	{
		Money = currMoney;
		GoldText.text = Money.ToString();
    }
}
