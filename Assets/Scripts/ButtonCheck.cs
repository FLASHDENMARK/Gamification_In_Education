using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonCheck : MiniGameBase
{
    void Awake ()
    {
        base.OnMiniGameStarted();
    }

    string[,] correctAnswers2D = new string[3, 4];
    InputField[] inputs = new InputField[4];
    public GameObject object1, object2, object3, object4;
    public ColorBlock cb;
    int j = 0, k = 0;

    public void Onclick()
    {
        object1 = GameObject.Find("Canvas/Inputfields/InputField1");
        object2 = GameObject.Find("Canvas/Inputfields/InputField2");
        object3 = GameObject.Find("Canvas/Inputfields/InputField3");
        object4 = GameObject.Find("Canvas/Inputfields/InputField4");

        inputs[0] = object1.GetComponent<InputField>();
        inputs[1] = object2.GetComponent<InputField>();
        inputs[2] = object3.GetComponent<InputField>();
        inputs[3] = object4.GetComponent<InputField>();

        correctAnswers2D[0, 0] = "3"; // mass
        correctAnswers2D[0, 1] = "4186"; // specific heat capacity of water
        correctAnswers2D[0, 2] = "85";  // temperature difference
        correctAnswers2D[0, 3] = "1067"; // Result in Kj

        correctAnswers2D[1, 0] = "1067000"; // energy in Kj
        correctAnswers2D[1, 1] = "12.75"; // mass
        correctAnswers2D[1, 2] = "4186"; // specific heat capacity of water
        correctAnswers2D[1, 3] = "20"; // result

        correctAnswers2D[2, 0] = "42"; // energy in Kj
        correctAnswers2D[2, 1] = "500"; // watt
        correctAnswers2D[2, 2] = ""; // empty
        correctAnswers2D[2, 3] = "84"; // minutes


        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i].text == correctAnswers2D[j, i])
            {
                
                ColorBlock cb = inputs[0].colors;
                cb.normalColor = Color.green;
                inputs[i].colors = cb;
                
            }
            else
            {
                ColorBlock cb = inputs[0].colors;
                cb.normalColor = Color.red;
                inputs[i].colors = cb;
            }
        }

        WaterBarChanger addWater = GameObject.Find("emptyTinCan/waterBar").GetComponent<WaterBarChanger>();
        Text correctText = GameObject.Find("Canvas/correctText").GetComponent<Text>();

        if (inputs[0].text == correctAnswers2D[j, 0] && inputs[1].text == correctAnswers2D[j, 1] && 
            inputs[2].text == correctAnswers2D[j, 2] && inputs[3].text == correctAnswers2D[j, 3])
        {
            addWater.MoreWater();
            addWater.MoreWater();
            j++;

            object2.GetComponent<InputField>().interactable = true;
            object3.GetComponent<InputField>().interactable = true;
            StartCoroutine(CorrectMethod());
            CorrectMethod();
            correctText.text = "Correct!";
        }
    }

    IEnumerator CorrectMethod()
    {
        Text assignmentText = GameObject.Find("Canvas/introText").GetComponent<Text>();
        k++;
        yield return new WaitForSeconds(2);

        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i].text = "";
            ColorBlock cb = inputs[0].colors;
            cb.normalColor = Color.white;
            inputs[i].colors = cb;
            GameObject.Find("Canvas/correctText").GetComponent<Text>().text = "";
        }

        Text unit1 = GameObject.Find("Canvas/Unit1").GetComponent<Text>();
        Text unit2 = GameObject.Find("Canvas/Unit2").GetComponent<Text>();

        if (k == 1)
        {
   
            if (Language.IsDanish)
            {
                assignmentText.text = "En mængde vand svarende til 17 dunke bliver tilført energien udregnet i opgaven før. "
                    + "Udregn den nuværende temperatur af vandet. Afrund resultatet til nærmeste hele tal.\n\n"
                    + "Husk at en dunk kan indeholde 0.75 liter vand, og at energimængden fra forrige opgave var 1067 kJ.\n\n"
                    + "I denne opgave skal du bruge punktum i stedet for komma hvis det bliver nødvendigt.\n"
                    + "Energimængden skal her skrives ind i joule.\n";

                unit1.text = "Energi (joule)";
                unit2.text = "Masse (kg)";
            }
            else
            {
                assignmentText.text = "An amount of water equal to 17 cans of water is being heated by the energy calculated before. "
                    + "Calculate the current temperature of the water. Round up the result to the nearest integer.\n\n"
                    + "Remember that a can of water can hold 0.75 litres of water, and that the energy calculated before was 1067 kJ.\n\n"
                    + "If necessary, use a period instead of a comma when writing numbers with decimals.\n"
                    + "The amount of energy should be entered in joules.";

                unit1.text = "Energy (joule)";
                unit2.text = "Mass (kg)";
            }

            GameObject.Find("Canvas/Unit3").GetComponent<Text>().text = "J/Kg*°C";

            object3.GetComponent<InputField>().interactable = false;
            object3.GetComponent<InputField>().text = "4186";
        }
        else if (k == 2)
        {

            if (Language.IsDanish)
            {
                assignmentText.text = "Bålet yder en effekt svarende til 500W. "
                    + "Der bruges 4186 joule ved en opvarmning af 1 kg vand med 1 grad celsius. "
                    + "Hvor lang tid tager det at varme 1 kg vand op med 10 grader?\n\n"
                    + "Ved komma-tal skal du runde op til nærmeste heltal.\n"
                    + "Jeg er sikker på at notesbogen kan hjælpe hvis det er nødvendigt.";

                unit1.text = "Energi (kJ)";
                unit2.text = "Joule/sekund";
            }
            else
            {
                assignmentText.text = "The fireplace yields an effect equal to 500W. "
                    + "4186 joule are used when heating up 1 kg of water one degree celsius."
                    + "How much time does it take to heat up 1 kg of water by 10 degrees?\n\n"
                    + "If a decimal-number appears, round up to nearest integer.\n"
                    + "I am sure that the journal has information that could be necessary to complete this task.";

                unit1.text = "Energy (kJ)";
                unit2.text = "Joule/second";
            }

            GameObject.Find("Canvas/Unit3").SetActive(false);

            object3.SetActive(false);
        }
        else if (k == 3)
        {
            base.OnMiniGameCompleted(1);
        }
    }
}