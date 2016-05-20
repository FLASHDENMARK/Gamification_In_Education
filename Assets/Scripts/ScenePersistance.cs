using UnityEngine;

public class ScenePersistance : MonoBehaviour 
{
	void Awake () 
	{
		// This tells the engine not to destoy this gameObject when loading a new scene/level
		DontDestroyOnLoad(this);
	}

	// Destroys this gameObject
	public void DestroyGameObject ()
	{
		Destroy(gameObject);
	}
}
