using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	public SceneFader sFaderRef;
	public string NextLevelName;

	[SerializeField]
	private int enemiesOnField = 0;
	[SerializeField]
	private int totalWaves = 0;

	public int EnemiesOnField { get { return enemiesOnField; } 
		set {
			enemiesOnField = value;
			//Dirty fix for this triggering twice. 
			if (enemiesOnField < 0) enemiesOnField = 0;
			
		} }

	public int TotalWaves
	{
		get { return totalWaves; }
		set { totalWaves = value; }
	}

	public int CurrentWaves
    {
		get; set;
    }


	public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
			Destroy(this);
			Debug.LogWarning("There is another Game Manager. Deleting This one");
        }
		else
        {
			Instance = this;
        }
    }
    void Start()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameIsOver)
			return;
		if (CurrentWaves >= TotalWaves)
		{
			if (EnemiesOnField <= 0)
			{
				WinLevel();
				
			}
		}
		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
	{
		
		Time.timeScale = 0f;
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel()
	{
		StartCoroutine(LocalTimer(1.0f, StopWinGame));
	}
	private void StopWinGame()
    {
		//Time.timeScale = 0f;
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}
	public void GoToNextLevel()
	{
		Time.timeScale = 1f;
		sFaderRef.FadeTo(NextLevelName);
	}
	private IEnumerator LocalTimer(float Timer, Action toDo)
    {
		yield return new WaitForSeconds(Timer);
		toDo?.Invoke();
    }

	public void AddToWaves(int waves)
    {
		totalWaves += waves;
    }
}
