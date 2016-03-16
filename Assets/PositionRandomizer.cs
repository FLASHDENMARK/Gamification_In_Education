using UnityEngine;
using System.Collections;

public class PositionRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RandomizePosition() {
        Vector2 tempVect = transform.position;
        tempVect.x = Random.Range(0, 3);
        tempVect.y = Random.Range(0, 3);
        transform.position = tempVect;
    }
}
