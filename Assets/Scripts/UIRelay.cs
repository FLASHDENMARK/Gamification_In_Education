using UnityEngine;
using System.Collections;


// Don't know if we need this, but we can easily delete it if not.
public class UIRelay : MonoBehaviour 
{
	static UIManager manager; 
	public Transform UIWindow;

	void Awake ()
	{
		DontDestroyOnLoad(this);
		Transform canvas = GameObject.Find("Canvas").transform;
		DontDestroyOnLoad(canvas.gameObject);

		if (!UIWindow)
		{
			throw new System.NullReferenceException("No UIWindow was assigned");
		}
		else
		{
			Transform t = Instantiate(UIWindow);
			t.gameObject.SetActive(false);
			t.SetParent(canvas, false);

			manager = t.GetComponent<UIManager>();
		
			if (!manager)
			{
				throw new System.NullReferenceException("No UIManager was found!");
			}
		}

		TextNotification("Welcome!", "You wake up, on a strange island. You notice a journal, lying on the ground. Is is a professors journal. You pick it up, and can now access it by pressing tab.");
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
