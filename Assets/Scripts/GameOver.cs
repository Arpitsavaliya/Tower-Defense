using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	public void Retry ()
	{
		Time.timeScale = 1f;
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

	public void Menu ()
	{
		Time.timeScale = 1f;
		sceneFader.FadeTo(menuSceneName);
	}

}
