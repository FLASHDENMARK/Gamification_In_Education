using UnityEngine;
using System.Collections;

public class SetLanguage : MonoBehaviour 
{
	public GameObject languagePanel;

	public void SetLanguageToEnglish ()
	{
		Language.IsDanish = false;
		ChangeLanguage();
	}

	public void SetLanguageToDanish ()
	{
		Language.IsDanish = true;
		ChangeLanguage();
	}	

	void ChangeLanguage ()
	{
		Language.ChangeLanguage();
		Destroy(languagePanel);
	}
}
