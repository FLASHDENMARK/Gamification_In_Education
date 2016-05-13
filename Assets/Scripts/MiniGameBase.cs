using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameBase : MonoBehaviour, IMiniGame 
{
	public GameObject beginPanel;
	public GameObject victoryPanel;

	public void OnMiniGameStarted ()
	{
		beginPanel.SetActive(true);
	}

	// When a Mini Game has been completed, we will progress further in the game
	// Returns to the Main Menu
	public void OnMiniGameCompleted (int obj)
	{
        victoryPanel.SetActive(true);

        GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[obj].level++;
        SceneManager.LoadScene(0);
	}

	// If the user decides to leave the Mini Game, return to the Main Menu
	public void OnMiniGameAbandoned ()
	{
		SceneManager.LoadScene(0);
	}
}
