using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    // Statically accessible 
    public static bool ShowMenu = false;

    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            ShowMenu = !ShowMenu;
    }

    void OnGUI () 
    {
        if (ShowMenu) 
        {
            int oldFontSize = GUI.skin.button.fontSize;
            GUI.Box(new Rect(0, 0, 20000, 10000), "");
            GUI.Box(new Rect(0, 0, 20000, 10000), "");
            GUI.Box(new Rect(0, 0, 20000, 10000), "");

            GUI.skin.button.fontSize = (int)(Screen.height * 0.05f);
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Main Menu"))
                SceneManager.LoadScene(0);
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 6, Screen.width / 6, Screen.height / 10), "Survey"))
                Application.OpenURL("https://da.surveymonkey.com/r/6NK3XYZ");
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 1.5f, Screen.width / 6, Screen.height / 10), "Exit Game"))
                Application.Quit();
            GUI.skin.button.fontSize = oldFontSize;
        }
    }
}
