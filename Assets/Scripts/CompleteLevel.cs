using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public int levelToUnlock = 2;

	public SceneFader sceneFader;

	public void Continue ()
	{
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		sceneFader.FadeTo(menuSceneName);
	}

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
	}

}
