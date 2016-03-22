using UnityEngine;
using System.Collections;


// Don't know if we need this, but we can easily delete it if not.
public class UIRelay : MonoBehaviour 
{
	static UIManager manager; 

	void Awake ()
	{
		manager = GetComponent<UIManager>(); 

		if (!manager)
		{
			throw new System.NullReferenceException("No Canvas was found!");
		}
	}

	public static void TextNotification (string headline, string message)
	{
		manager.TextNotification(headline, message);
	}

	public static void TextNotificationWithAck (string headline, string message, MonoBehaviour mono)
	{
		manager.TextNotificationWithAck(headline, message, mono);
	}

	public static void TextNotificationWithAccept (string headline, string message, MonoBehaviour mono)
	{
		manager.TextNotificationWithAccept(headline, message, mono);
	}

	public static void TextNotificationWithQuiz (string headline, string message, string[] answers, MonoBehaviour mono)
	{
		manager.TextNotificationWithQuiz(headline, message, answers, mono);
	}
}
