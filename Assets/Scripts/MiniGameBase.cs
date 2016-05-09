using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameBase : MonoBehaviour, IMiniGame 
{
	// When a Mini Game has been completed we will progress further in the game
	public void OnMiniGameCompleted (int obj)
	{
        GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[obj].level++;
        SceneManager.LoadScene(0);
	}

	public void OnMiniGameAbandoned ()
	{
		SceneManager.LoadScene(0);
	}
}
