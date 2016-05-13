using UnityEngine;

public class ScenePersistance : MonoBehaviour 
{
	void Awake () 
	{
		Debug.LogError("Calling DontDestroyOnLoad");
		DontDestroyOnLoad(this);
	}

	public void DestroyGameObject ()
	{
		Destroy(gameObject);
	}
}
