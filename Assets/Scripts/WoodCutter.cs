using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WoodCutter : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void check()
    {
        StartCoroutine(checkAnswers());
    }

    IEnumerator checkAnswers()
    {
        int i = 0, score = 1;
        List<int> answers = new List<int>();
        int[] correctAnswers = {10, -330, 15, 40};
        Transform Canvas = GameObject.Find("Canvas/Answers").transform;
        foreach (Transform child in Canvas.transform)
        {
            int value;
            bool result = int.TryParse((child.GetChild(2).GetComponent<Text>().text), out value);
            if (result)
                if (value == correctAnswers[i])
                {
                    InputField inputfield = Canvas.GetChild(i).GetComponent<InputField>();
                    Debug.Log(inputfield.name);
                    Debug.Log(i);
                    ColorBlock CB = inputfield.colors;
                    CB.normalColor = Color.green;
                    inputfield.colors = CB;
                    yield return new WaitForSeconds(.5f);
                    CB.normalColor = Color.white;
                    inputfield.colors = CB;
                    yield return new WaitForSeconds(.5f);
                    CB.normalColor = Color.green;
                    inputfield.colors = CB;
                    yield return new WaitForSeconds(.5f);
                    CB.normalColor = Color.white;
                    inputfield.colors = CB;
                    i++;
                    score++;
                }
                else
                {
                    InputField inputfield = Canvas.GetChild(i).GetComponent<InputField>();
                    ColorBlock CB = inputfield.colors;
                    CB.normalColor = Color.red;
                    inputfield.colors = CB;
                    yield return new WaitForSeconds(.5f);
                    CB.normalColor = Color.white;
                    inputfield.colors = CB;
                    yield return new WaitForSeconds(.5f);
                    CB.normalColor = Color.red;
                    inputfield.colors = CB;
                    yield return new WaitForSeconds(.5f);
                    CB.normalColor = Color.white;
                    inputfield.colors = CB;
                    i++;
                }
        }
        if (score > 4)
            Debug.Log("COMPLETE");
    }
}
