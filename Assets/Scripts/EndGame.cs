using UnityEngine;

// This code handles the behavior for the very last element ouf our game.
public class EndGame : MonoBehaviour 
{
	// This gameObject displays a "thank you for playing UI element"
	public GameObject endGameScreen;
	// This gameObject shows the 7 people who made this program/project
	public GameObject developerScreen;
	bool _fading = false;

	void Update ()
	{
		// This fades the endGameScreen and gradually shows the developer screen behind it
		// instead of abruptly appearing.
		if (_fading)
		{
			endGameScreen.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;

			// Is the endGameScreen now completely invisible? 
			if (endGameScreen.GetComponent<CanvasGroup>().alpha <= 0)
			{
				// Disable it
				endGameScreen.SetActive(false);
			}
		}
	}

	// Called once every Minigame has been completed
	public void GameCompleted ()
	{
		// Activate two UI screens. 
		endGameScreen.SetActive(true);
		developerScreen.SetActive(true);
	}

	// Called when the user has clicked "continue" on the endGameScreen
	public void ShowDevelopers ()
	{
		_fading = true;
	}

	// Called when the user has clicked "continue" on the developerScreen
	public void QuitApplication ()
	{
		Application.Quit();
	}
}
