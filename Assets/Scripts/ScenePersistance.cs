using UnityEngine;

public class ScenePersistance : MonoBehaviour 
{
	void Awake () 
	{
		DontDestroyOnLoad(this);
	}

	public void DestroyGameObject ()
	{
		Destroy(gameObject);
	}
}
