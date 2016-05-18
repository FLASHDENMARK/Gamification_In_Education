using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour 
{
	public GameObject endGameScreen;
	public GameObject developerScreen;
	bool fading = false;

	void Update ()
	{
		if (fading)
		{
			endGameScreen.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;

			if (endGameScreen.GetComponent<CanvasGroup>().alpha <= 0)
				endGameScreen.SetActive(false);
		}
	}

	public void GameCompleted ()
	{
		endGameScreen.SetActive(true);
		developerScreen.SetActive(true);
	}

	public void ShowDevelopers ()
	{
		fading = true;
	}

	public void QuitApplication ()
	{
		Application.Quit();
	}
}
