using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    bool _showMenu = false;
    int oldFontSize;
    // Update is called once per frame


    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            _showMenu = !_showMenu;
    }

    void OnGUI() {
        if (_showMenu) {
            oldFontSize = GUI.skin.button.fontSize;
            GUI.Box(new Rect(0, 0, 20000, 10000), "");
            GUI.Box(new Rect(0, 0, 20000, 10000), "");
            GUI.Box(new Rect(0, 0, 20000, 10000), "");

            GUI.skin.button.fontSize = (int)(Screen.height * 0.05f);
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 1.5f, Screen.width / 6, Screen.height / 10), "Main Menu"))
                SceneManager.LoadScene(0);
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 12, Screen.height / 2, Screen.width / 6, Screen.height / 10), "Survey"))
                Application.OpenURL("https://da.surveymonkey.com/r/6NK3XYZ");
            GUI.skin.button.fontSize = oldFontSize;
        }
    }
}
