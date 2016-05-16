using UnityEngine;

public class Language : MonoBehaviour 
{
	// English is the default language
	public static bool IsDanish = false;

	public delegate void LanguageChange();
	public static event LanguageChange language;

	public static void ChangeLanguage ()
	{
		language.Invoke();
	}
}
