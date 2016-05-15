using UnityEngine;
using UnityEngine.UI;

public class ApplyLanguage : MonoBehaviour 
{
	public Text label;
	public Text mainText;

	public string danishLabel;

	[TextArea(4, 10)]
	public string danishMain;

	void Awake ()
	{
		Language.language += Translate;

		if (Language.IsDanish)
		{
			Translate();
		}
	}

	void Translate ()
	{
		if (label)
		{
			if (Language.IsDanish)
				label.text = danishLabel;
		}

		if (mainText)
		{
			if (Language.IsDanish)
				mainText.text = danishMain;
		}
	}
}
