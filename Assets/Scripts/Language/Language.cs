using UnityEngine;

public class Language : MonoBehaviour 
{
	public GameObject languagePanel;

	// English is the default language
	public static bool IsDanish = false;

	public delegate void LanguageChange();
	public static event LanguageChange OnLanguageChanged;


	// Automatically called by the languagePanel when the user selects English
	public void SetLanguageToEnglish ()
	{
		IsDanish = false;
		ChangeLanguage();
	}

	// Automatically called by the languagePanel when the user selects Danish
	public void SetLanguageToDanish ()
	{
		IsDanish = true;
		ChangeLanguage();
	}	

	public void ChangeLanguage ()
	{
		// Unity3D doesn't support the Null-conditional operator for thread safe invocation
		// However by default Unity3D is single threaded, so this should be of no concern
		OnLanguageChanged.Invoke();
		Destroy(languagePanel);
	}
}

