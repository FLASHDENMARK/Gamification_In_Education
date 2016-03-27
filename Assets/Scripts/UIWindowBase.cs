using UnityEngine;
using UnityEngine.UI;

// MonoBehaviour is a necessity for 
public class UIWindowBase : MonoBehaviour 
{
	public Text headline;
	public Text body;

	public GameObject acceptDeny;
	public GameObject confirm;

	// Not a part of base:::
	public GameObject quizParent;
	public Text[] quizTexts;

	// Sets the headline of the UI window
	public virtual void SetHeadline (string s)
	{
		headline.text = s;
	}

	// Sets the text body of the UI window
	public void SetBody (string s)
	{
		body.text = s;
	}

	// Enables and disables all quiz buttons based on the amount of questions
	public void InitializeQuiz (string[] questions)
	{
		InitializeQuiz(true);

		if (questions.Length > quizTexts.Length)
		{
			throw new System.IndexOutOfRangeException("Too many answers");
		}
		else
		{
			for (int index = 0; index < quizTexts.Length; index++)
			{
				if (index < questions.Length)
				{
					quizTexts[index].transform.parent.gameObject.SetActive(true);
					quizTexts[index].text = questions[index];	
				}
				else
				{
					quizTexts[index].transform.parent.gameObject.SetActive(false);
				}
			}
		}
	}

	// Enables/disables all the UI elements needed for a quiz 
	public void InitializeQuiz (bool state)
	{
		quizParent.SetActive(state);
		acceptDeny.SetActive(false);
		confirm.SetActive(false);
	}

	// Enables/disables the "Yes" and "No" buttons
	public void InitializeAcceptOrDeny (bool state)
	{
		acceptDeny.SetActive(state);
		quizParent.SetActive(false);
		confirm.SetActive(false);
	}

	// Enables/disables the "Confirm" button
	public void InitializeConfirm (bool state)
	{
		confirm.SetActive(state);
		quizParent.SetActive(false);
		acceptDeny.SetActive(false);
	}
}