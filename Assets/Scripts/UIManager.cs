using UnityEngine;
using System.Collections;
// Lets us use Unity UI tools in code
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public UIWindowBase textWindow;

	// Initializes a UI window with plain text and a button.
	public void TextNotification (string headline, string message)
	{
		// Activates the object
		textWindow.gameObject.SetActive(true);
		// Set the text of the window
		textWindow.SetHeadline(headline);
		textWindow.SetBody(message);
	}

	MonoBehaviour delegateMono;

	public void TextNotificationWithAck (string headline, string message, MonoBehaviour mono)
	{
		delegateMono = mono;

		TextNotification(headline, message);
		textWindow.InitializeConfirm(true);
	}

	public void TextNotificationWithAccept (string headline, string message, MonoBehaviour mono)
	{
		delegateMono = mono;

		TextNotification(headline, message);
		textWindow.InitializeAcceptOrDeny(true);
	}

	public void TextNotificationWithQuiz (string headline, string message, string[] answers, MonoBehaviour mono)
	{
		delegateMono = mono;

		TextNotification(headline, message);
		textWindow.InitializeQuiz(answers);
	}

	public void OnConfirmedOrDenied (bool answer)
	{
		DisableNotification();

		if (delegateMono)
			delegateMono.SendMessage("OnClickConfirmed", answer);
	}

	public void OnQuizWasAnswered (int answer)
	{
		if (delegateMono)
			delegateMono.SendMessage("OnClickQuiz", answer);
	}

	// Called directly from the UI element
	public void DisableNotification ()
	{
		textWindow.gameObject.SetActive(false);
	}
}
