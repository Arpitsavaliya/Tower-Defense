using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	public SceneFader sFaderRef;
	public string NextLevelName;

	void Start()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameIsOver)
			return;

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
		Time.timeScale = 0f;
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}
	public void GoToNextLevel()
	{
		Time.timeScale = 1f;
		sFaderRef.FadeTo(NextLevelName);
	}
}
