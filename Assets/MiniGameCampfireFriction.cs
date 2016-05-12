using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameCampfireFriction : MonoBehaviour {
    public GameObject stick;
    public Transform target;
    public Transform target2;
    public Image smoke; 
    public float speed;
    bool atBottom = false;

	void Update () {
        float step = speed * Time.deltaTime;

        if (Vector3.Distance(target.position, stick.transform.position) < 0.1f)
            atBottom = true;
        else if (Vector3.Distance(target2.position, stick.transform.position) < 0.1f)
            atBottom = false;
        if(!atBottom)
            stick.transform.position = Vector3.MoveTowards(stick.transform.position, target.position, step);
        else
            stick.transform.position = Vector3.MoveTowards(stick.transform.position, target2.position, step);
    }
}
