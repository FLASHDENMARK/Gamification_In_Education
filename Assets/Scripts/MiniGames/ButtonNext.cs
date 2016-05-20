using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonNext : MonoBehaviour { 
	private int state = 1;
	GameObject content;
	GameObject nextButton;
	string content_text;
	bool _next = false, _done = true;
	public GameObject inputs, CalcHouseGO;
	int status = 0;

	// Use this for initialization
	void Start () {
		content = GameObject.Find ("Assaignment-content");

		inputs.SetActive (false);
		CalcHouseGO.SetActive (false);
	}
		
	// Update is called once per frame
	void Update () {
		switch (state) {
		case 1: // Wood chopping mini
			if (_next) {
				_next = false;
				if (inputs.transform.FindChild ("Ans1").GetComponent<InputField> ().text == "13" &&
					inputs.transform.FindChild ("Ans4").GetComponent<InputField> ().text == "1"  &&
					inputs.transform.FindChild ("Ans3").GetComponent<InputField> ().text == "14" &&
					inputs.transform.FindChild ("Ans2").GetComponent<InputField> ().text == "12") {
					_done = true;
					inputs.SetActive (false);
					onClick ();
				} else {
					Debug.Log ("Wrong");
				}

			}
			break;

		case 3: // Calc house area
			Debug.Log(status);

			if (_next && status == 0)
				status++;
			
			if (_next && status == 1) {
				_next = false;
				CalcHouseGO.transform.FindChild ("Opgaver-samlet").gameObject.SetActive (false);
				status++;
			}
			break;
		
		}

	}

	public void onClick()
	{
		_next = true;
		if (_done) {
			state++;

			switch (state) {
			case 1:
				ChopWood ();
				break;
			case 2:
				content.GetComponent<Text> ().text = "Wood Chopped.\n" +
					"In order to build you house, you now need to calculate the space\n" +
					"that the house is taking.\n" +
					"Hit 'Next' to begin.";
				break;
			case 3:
				CalculateHouse ();
				break;
			default:
				content.GetComponent<Text> ().text = "Done.";
				break;
			}

			Debug.Log (state);
		}
	}

	public void CalculateHouse(){
		_done = false;

		CalcHouseGO.SetActive (true);

		content.GetComponent<Text> ().text = "This is your house.\n\n" +
			"Click 'Next to start calculating the house.";
	}

	public void ChopWood(){
		_done = false;

		inputs.SetActive (true);

		content.GetComponent<Text> ().text = "You need to chop wood.\n" +
		"Calculate the equations below.\n\n" +
		"1234142215+124214213214 = \n\n" +
		"123214214+1242414214122 = \n\n" +
		"2131414424+214214214214 = \n\n" +
		"124213214241+2142414212 =";
	}
}
