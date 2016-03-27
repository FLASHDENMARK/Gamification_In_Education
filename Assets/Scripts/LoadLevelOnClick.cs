using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnClick : MonoBehaviour, IClickable
{
	public string loadLevel;
	public string UIHeadline;
	public string UIBody;

	public string[] answers;
	public int correctAnswer;

	void Awake ()
	{
		SceneManager.LoadScene(loadLevel);
	}

	// Is called when the object containing this script is clicked on
	public void OnClick ()
	{
		//UIRelay.TextNotificationWithQuiz(UIHeadline, UIBody, answers, this);
		//UIRelay.TextNotificationWithAccept(UIHeadline, UIBody, this);
		//UIRelay.TextNotification (UIHeadline, UIBody);
	}

	// The user pressed yes / no
	public void OnConfirmedOrDenied (bool answer)
	{
		Debug.LogError("The user answered: " + answer);

		if (answer)
			SceneManager.LoadScene(loadLevel);
	}

	// The user answered the quiz 
	public void OnQuizWasAnswered (int answer)
	{
		if (answer == correctAnswer)
		{
			UIRelay.TextNotificationWithAck ("You answered correct", "Insert things about theory", this);
		}
		else
		{
			UIRelay.TextNotificationWithAck ("You fucked it up!", "Insert things about theory", this);
		}
	}
}