using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public string levelSelector = "LevelSelect";

	public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}

	public void ToLevelSelector()
    {
		sceneFader.FadeTo(levelSelector);
	}

	public void Quit ()
	{
		Application.Quit();
	}

}
