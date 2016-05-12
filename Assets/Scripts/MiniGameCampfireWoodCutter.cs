using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MiniGameCampfireWoodCutter : MiniGameBase 
{
    public void Check ()
    {
        StartCoroutine(CheckAnswers());
    }

    IEnumerator CheckAnswers ()
    {
        int i = 0, score = 0;
		double[] correctAnswers = {(15-10*3+4*5+10*0.5d), (15-10*(3+4)*5+10*0.5d), 
            (15-10*3+4*(5+10)*0.5d), ((15-10)*3+4*5+10*0.5d)};
        Transform Canvas = GameObject.Find("Canvas/Answers").transform;

        foreach (Transform child in Canvas.transform)
        {
            int value;
            if (int.TryParse((child.GetChild(2).GetComponent<Text>().text), out value))
            {
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
        }

        if (score == 4) 
        { 
            base.OnMiniGameCompleted(0);
        }
    }
}
