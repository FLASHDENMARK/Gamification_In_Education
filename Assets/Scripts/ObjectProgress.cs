using UnityEngine;
using System.Collections;

public class ObjectProgress : MonoBehaviour {

    public bool[] level;
    public Progress[] progress;
            
    [System.Serializable]
    public class Progress
    {
        public ObjectSomething[] dependencies;

        public bool isDone = false;
        public GameObject[] assets;

        public void CheckUnlock ()
        {
            int unlocks = 0;
            foreach(ObjectSomething o in dependencies)
            {
                if (o.isDone)
                    unlocks++;
            }

            if (unlocks == dependencies.Length)
                this.isDone = true;
        }
    }



	// Use this for initialization
	void Start () {
        //progress[missionLevel] = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
