using UnityEngine;
using UnityEngine.UI;

// Is in charge of translating any in-engine text.
public class ApplyLanguage : MonoBehaviour 
{
	public Text label;
	public Text mainText;

	public string danishLabel;

	[TextArea(4, 10)]
	public string danishMain;

	void Awake ()
	{
		Language.OnLanguageChanged += Translate;

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
