using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaterBarChanger : MonoBehaviour {

    public Vector3 startpos;
    float down = 0.05f;
    public GameObject waterBar;

	// Use this for initialization
	void Start ()
    {
        waterBar = GameObject.Find("emptyTinCan/waterBar");
        startpos = waterBar.transform.localPosition;

        waterBar.transform.localScale = new Vector3(0.75f, down, 0);
        waterBar.transform.localPosition = startpos + new Vector3(0, down * 1.3f, -3);

        down = down + 0.1f;

    }

    public void MoreWater()
    {
        waterBar = GameObject.Find("emptyTinCan/waterBar");
        waterBar.transform.localScale = new Vector3(0.75f, down, 0);
        waterBar.transform.localPosition = startpos + new Vector3(0, down * 1.3f, -3);

        down = down + 0.1f;
    }
}
