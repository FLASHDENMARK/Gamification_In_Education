﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/*
	To do: 
	Seperate these two classes into two seperate files?
	Implement into new UI system? (Pro: scales better, con: is a bitch to implement!)
	Scroll bar,
	Pictures (how?)
	Implement custom exception in JournalEntryBase when assigning "" to Headline or Body
	Convert GetBody, GetHeadline and GetSelectionIndex into Properties instead of methods?
*/

class Menu : JournalEntryBase
{
	List<JournalEntryBase> journalEntries = new List<JournalEntryBase>();
	string _subject;
	int selection;

	// Property
	public string Subject 
	{
		get
		{
			return _subject;
		}
		private set
		{
			_subject = value;
		}
	}
	
	// Constructor. Calls Super Class Constructor
	public Menu (string subject) : base (subject, "")
	{
		this.Subject = subject;
	}

	// Adds a new entry to the list of entriesx
	public void AddJournalEntry (JournalEntryBase entry)
	{
		journalEntries.Add(entry);
	}

	// Returns a list of all entries
	public override List<JournalEntryBase> GetEntries ()
	{
		return journalEntries;
	}

	// Selects a new entry
	public override void Select (int selection)
	{
		this.selection = selection;
	}

	// Returns the selection
	public int GetSelectionIndex ()
	{
		return selection;
	}

	// Returns the body (text) of the selected entry
	public string GetBody ()
	{
		return journalEntries[selection].Body;
	}

	// Returns the headline (text) of the selected entry
	public string GetHeadline ()
	{
		return journalEntries[selection].Headline;
	}
}

// Manages the main behaviour of the journal 
class JournalManager : MonoBehaviour 
{
	// A list of all subjects
	List<Menu> subjects = new List<Menu>();
	// Index of selected entry
	int selection;
	// The body (text) of the selected entry
	string body;
	// The position and scale of the UI Window (assigned through Inspector)
	public Rect windowRect;
	// Show the journal or not
	bool showJournal;
	// The Keycode (button input) to toggle the journal on/off
	KeyCode show = KeyCode.Tab;
	// The color of the highlighted GUI
	Color highlight = Color.grey;

	// Adds a new subject to the list of subjects
	public void AddSubject (Menu menu)
	{
		subjects.Add(menu);
	}

	// Is called once when the application starts
	void Start () 
	{
		// Mathematical subjects
		Menu mathematics = new Menu("Mathematics");
		string phytagoreanTheorem = 
		"The Phytagorean Theorem is a <i>very</i> important equation in mathematics. It states that "
		+ "the hypotenuse (the side opposite the right angle) of a right angled triangle is equal to the "
		+ "sum of the squares of the other two sides. The Pythagorean equation is written as follows: "
		+ "\n\n <b>a^2 + b^2 = c^2</b> \n\n"
		+ "This equation has many applications, such as Trigonometry and Physics."
		+ "\n\n More!!";

		// This adds an entry to the mathematics menu
		mathematics.AddJournalEntry(new JournalEntry("Phytagorean Theorem", phytagoreanTheorem));
		
		string orderOfOperations = "";
		mathematics.AddJournalEntry(new JournalEntry("Order of Operations", orderOfOperations));

		string geometry = "";
		mathematics.AddJournalEntry(new JournalEntry("Geometry", geometry));

		// Physics subjects 
		Menu physics = new Menu("Physics");
        string fireTriangle =
        "<b>\t   Day: 34 - Analysis of fire.</b>"
        + "\n\nI have spend the entire day, analysing the behaviour of fire, and i think i have figured it out. "
        + "It seems that the ability to create a fire is based on three primary factors. "
        + "I have not been able to produce a fire without these components, so they seem important to creating a fire. "
        + "\n\nFirstly to create a fire, i need something that can serve as a fuel, something that can burn. \n\n"
        + "I have also found that creating a fire in an oxygenless environment is impossible. It seems that oxygen is a key"
        + "component too. \n\nLastly i have found that the reaction, that is fire, can be started by raising the fuel to it's"
        + "Ignition temperature, as long as the other two components are present.\n\n\n"
        + "I am fairly certain this information will come in handy at some point."
        + "\n\n <i>-- Prof. Jameson</i>";
		physics.AddJournalEntry(new JournalEntry("Fire Triangle", fireTriangle));

        string waterDistillation =
        "<b>\t   Day: 37 - Distilling of saltwater.</b>"
        + "\n\nI have though of a way to make drinkable water! i just need a container to hold the water "
        + "then i can boil it and cool the steam to turn it into drinkable water. ";

		physics.AddJournalEntry(new JournalEntry("Water distillation", waterDistillation));

		string velocity = "";
		physics.AddJournalEntry(new JournalEntry("Velocity", velocity));

		// Extra subjects
		Menu tingOgSager = new Menu("Add Subject");
		tingOgSager.AddJournalEntry(new JournalEntry("Add Entry", "Add Body"));
		
		AddSubject(mathematics);
		AddSubject(physics);
		AddSubject(tingOgSager);
	}

	// Called every frame
	void Update ()
	{
		if (Input.GetKeyDown(show))
		{
			showJournal = !showJournal; 
		}
	}

	// Called every frame and draws UI elements on screen
	void OnGUI ()
	{
        GUI.backgroundColor = new Color(0, 0, 0, 1);
        GUI.contentColor = Color.white;
        // Let the user know how to toggle the Journal on and off
        GUI.Box(new Rect(0, Screen.height - 20, 280, 30), "");
        GUI.Label(new Rect(10, Screen.height - 20, 350, 30), 
			"Press " + show.ToString() + " to " + (showJournal? "hide" : "show") + " the Professor's Journal");

        // Return if the journal shouldn't be show
        if (!showJournal) {
            return;
        }
        else {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        }

		// Assigns the current subject to a temp value for easy access
		Menu currentSubject = subjects[selection];
		// Sets body (text) to the body of the current subject
		body = currentSubject.GetBody();
		
		// Iterates through all subjects
		for (int index = 0; index < subjects.Count; index++)
		{
			// Highlights the current selected subject 
			if (index == selection)
			{
				Highlight();
			}

			// Draws a button for each subject
			if (GUI.Button(new Rect(50, 50 + index * 35, 150, 30), subjects[index].Subject))
			{
				selection = index;
				currentSubject = subjects[selection];
			}

			// Resets the GUI color
			ResetHighlight();

			// Starts drawing a UI Window
			windowRect = GUI.Window(0, windowRect, TheoryUIWindow, currentSubject.GetHeadline());
		}

		// Temp list of all entries in the current subject
		List<JournalEntryBase> entries = currentSubject.GetEntries();

		// Iterates through all entries
		for (int b = 0; b < entries.Count; b++)
		{
			// Highlights the current selected subject
			if (b == currentSubject.GetSelectionIndex())
			{
				Highlight();
			}

			// Draw a button for each entriy and check if it has been clicked
			if (GUI.Button(new Rect(200, 50 + b * 35, 200, 30), entries[b].Headline))
			{
				// Select the entry that was clicked
				currentSubject.Select(b);
			}

			// Resets the GUI color
			ResetHighlight();
		}
	}

    public GUIStyle penis;

    void TheoryUIWindow (int windowID) 
    {
    	// Draws the body (text) for the current topic, inside a UI Window
        GUI.Label(new Rect(10, 20, windowRect.width - 10, 350), body, penis);

        Texture2D penisTexture = new Texture2D(2, 2);
//        float height = penis.CalcHeight(new GUIContent(body), windowRect.width - 10);

        //GUI.DrawTexture(new Rect(10, 20 + height, windowRect.width - 10, 350), penisTexture);
      
    }

    void Highlight ()
    {
    	GUI.contentColor = highlight;
    }

    void ResetHighlight ()
    {
    	GUI.contentColor = Color.white;
    }
}