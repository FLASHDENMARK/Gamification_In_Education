using UnityEngine;
using System.Collections;

public class SetLanguage : MonoBehaviour 
{
	public GameObject languagePanel;

	public void SetLanguageToEnglish ()
	{
		Language.IsDanish = false;
		Language.ChangeLanguage();
		Destroy(languagePanel);
	}

	public void SetLanguageToDanish ()
	{
		Language.IsDanish = true;
		Language.ChangeLanguage();
		Destroy(languagePanel);
	}	
}
