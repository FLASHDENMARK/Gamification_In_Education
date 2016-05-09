using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Manages the main behaviour of the journal 
class JournalManager : MonoBehaviour 
{
	// A list of all subjects
	List<JournalMenu> subjects = new List<JournalMenu>();
	// Index of selected entry
	int _selection;
	// The body (text) of the selected entry
	string _body;
	// The position and scale of the UI Window (assigned through Inspector)
	public Rect windowRect;
	// Show the journal or not
	bool _showJournal;
	// The Keycode (button input) to toggle the journal on/off
	KeyCode _showKey = KeyCode.Tab;
	// The color of the highlighted GUI
	Color _highlight = Color.grey;

	// Adds a new subject to the list of subjects
	public void AddSubject (JournalMenu JournalMenu)
	{
		subjects.Add(JournalMenu);
	}

	// Is called once when the application starts
	void Start () 
	{
		// Intro	
        JournalMenu intro = new JournalMenu("Intro");
        string aboutJournal =
        "<b>This journal belongs to Science Professor Jameson</b>"
        + "\n\nThis journal contains the discoveries I have done, through various experiments."
        + " The finds are divided into chapters of their respective subjects."
        + "\n\nIf you are to find this book, please return it to me."
        + "\n\n<i>-- Prof. Jameson</i>";

        intro.AddJournalEntry(new JournalEntry("About This Journal", aboutJournal));

        // Mathematical subjects
        JournalMenu mathematics = new JournalMenu("Mathematics");
		string phytagoreanTheorem = 
		"The Phytagorean Theorem is a <i>very</i> important equation in mathematics. It states that "
		+ "the hypotenuse (the side opposite the right angle) of a right angled triangle is equal to the "
		+ "sum of the squares of the other two sides. The Pythagorean equation is written as follows: "
		+ "\n\n <b>a^2 + b^2 = c^2</b> \n\n"
		+ "This equation has many applications, such as Trigonometry and Physics."
		+ "\n\n More!!";

		// This adds an entry to the mathematics JournalMenu
		mathematics.AddJournalEntry(new JournalEntry("Phytagorean Theorem", phytagoreanTheorem));

        string orderOfOperations = "It seems that math can be misleading at times."
        + "\nI have found that the order of operations is quite important."
        + "\n\nHere's an example:"
        + "\nWe have two sticks, and then 4 sets of 3 sticks."
        + "\n || +(||| + ||| + ||| + |||)"
        + "\n\nThe mathematcial equation would then be:"
        + "\n\n<b>2+3×4</b>"
        + "\n2+3 = 5, that leaves us with 5×4."
        + "\n5×4 = 20 right? Wrong. Count the sticks for yourself, are there 20 sticks above?"
        + "\nNo, right? The correct equation would be:"
        + "\n\n<b>2+3×4</b>"
        + "\n3×4 = 12, which leaves us with: 2 + 12 = 14."
        + "\n14 sticks, just as above."
        + "\n\nIt seems that you have to multiply and divide, before addition and subtraction, to get the right result."
        + "\nFurthermore it seems that parenthesis should be calculated as the very first thing of an equation."
        + "\nthen we should calculate roots and exponents, then multiplication and division, and lastly addition and subtraction."
        + "\n\nI have come up with an easier way to remember this order. I call it PEMDAS and it stands for"
        + "\nParentheses, exponents, multiply, devide, add and subtract."
        + "\n\nAs long as equations are calculated in this order, then the result will always be correct."
        +"\n\n<i>-- Prof. Jameson</i>";

        mathematics.AddJournalEntry(new JournalEntry("Order of Operations", orderOfOperations));

		string geometry = "";
		mathematics.AddJournalEntry(new JournalEntry("Geometry", geometry));

		// Physics subjects 
		JournalMenu physics = new JournalMenu("Physics");
        string fireTriangle =
        "<b>\tDay: 34 - Analysis of fire</b>"
        + "\n\nI have spend the entire day, analyzing the behaviour of fire, and I think I have figured it out. "
        + "It seems that the ability to create a fire is based on three primary factors. "
        + "I have not been able to produce a fire without these components, so they seem important to creating a fire. "
        + "\n\nFirstly to create a fire, I need something that can serve as a fuel, something that can burn. \n\n"
        + "I have also found that creating a fire in an oxygenless environment is impossible. It seems that oxygen is a key "
        + "component too. \n\nLastly I have found that the reaction, that is fire, can be started by raising the fuel to it's"
        + " Ignition temperature, as long as the other two components are present.\n\n\n"
        + "I am fairly certain this information will come in handy at some point."
        + "\n\n <i>-- Prof. Jameson</i>";
		physics.AddJournalEntry(new JournalEntry("Fire Triangle", fireTriangle));

        string waterDistillation =
        "<b>\tDay: 37 - Distilling of saltwater</b>"
        + "\n\nI have though of a way to make drinkable water! i just need a container to hold the water "
        + "then i can boil it and cool the steam to turn it into drinkable water. ";

		physics.AddJournalEntry(new JournalEntry("Water distillation", waterDistillation));

		string velocity = "";
		physics.AddJournalEntry(new JournalEntry("Velocity", velocity));

        AddSubject(intro);
		AddSubject(mathematics);
		AddSubject(physics);
	}

	// Called every frame
	void Update ()
	{
		if (Input.GetKeyDown(_showKey))
		{
			_showJournal = !_showJournal; 
		}
	}

	// Called every frame and draws UI elements on screen
	void OnGUI ()
	{
		ScaleToScreenSize();

        GUI.backgroundColor = new Color(0, 0, 0, 1);
        GUI.contentColor = Color.white;

        // Let the user know how to toggle the Journal on and off
        GUI.Box(new Rect(0, 450, 280, 30), "");
        GUI.Label(new Rect(10, 455, 350, 30), 
			"Press " + _showKey.ToString() + " to " + (_showJournal? "hide" : "show") + " the Professor's Journal");

        // Return if the journal shouldn't be show
        if (!_showJournal) {
            return;
        }
        else {
            GUI.Box(new Rect(0, 0, 20000, 10000), "");
            GUI.Box(new Rect(0, 0, 20000, 10000), "");
            GUI.Box(new Rect(0, 0, 20000, 10000), "");
        }

        DrawMenuAndSubjects();
	}

	void DrawMenuAndSubjects ()
	{
		// Assigns the current subject to a temp value for easy and quicker access
		JournalMenu currentSubject = subjects[_selection];
		// Store the body of the current subject for later use
		_body = currentSubject.Body;
		
		// Iterates through all subjects
		for (int index = 0; index < subjects.Count; index++)
		{
			// Highlights the current selected subject 
			if (index == _selection)
				Highlight();
			
			// Draws a button for each subject
			if (GUI.Button(new Rect(50, 50 + index * 35, 150, 30), subjects[index].Subject))
			{
				_selection = index;
				currentSubject = subjects[_selection];
			}

			// Resets the GUI color
			ResetHighlight();

			// Starts drawing a UI Window with the 
			windowRect = GUI.Window(0, windowRect, TheoryUIWindow, currentSubject.Headline);
		}

		// Temp list of all entries in the current subject
		List<JournalEntryBase> entries = currentSubject.Entries;

		// Iterates through all entries
		for (int b = 0; b < entries.Count; b++)
		{
			// Highlights the current selected subject
			if (b == currentSubject.Selection)
				Highlight();

			// Draw a button for each entry and check if it has been clicked
			if (GUI.Button(new Rect(200, 50 + b * 35, 200, 30), entries[b].Headline))
			{
				// Select the entry that was clicked
				currentSubject.Selection = b;
			}

			// Resets the GUI color
			ResetHighlight();
		}
	}

	Vector2 scrollPosition;

	// Draws the currently selected subject to the screen
    void TheoryUIWindow (int windowID) 
    {	
    	float width = windowRect.width-30;
    	// Calculates the height of the text we are about to draw. 
    	// Takes line shifts into account
    	float height = GUI.skin.label.CalcHeight(new GUIContent(_body), width);
    	// The XY position and XY width of a "scroll view", which allows us to scroll 
    	// through the text if it exceeds its boundaries
    	Rect scrollPosAndSize = new Rect(10, 20, width+20, 375);
    	// The current "scroll position" (how much we have scrolled up/down, left/right)
    	Rect scrollView = new Rect(0, 0, width, height);

    	// Draw a scroll view
	 	scrollPosition = GUI.BeginScrollView(scrollPosAndSize, scrollPosition, scrollView);
	 		// We draw the subject text inside the scroll view
        	GUI.Label(new Rect(0, 0, width, height), _body);
        // This "ends" the scroll view
        GUI.EndScrollView();
    }

    void ScaleToScreenSize ()
    {
		float screenWidth = Screen.width / 853.0F; // 853 is the native width of the original screen
		float screenHeight = Screen.height / 480.0F; // 480 is the native height of the original screen

		// This makes the UI scale automatically. It creates a Translation, Rotation and Scaling(TRS) matrix.
		// The returned matrix means that positions, rotations and scale that once fit the native width/height 
		// will now scale properly on (almost) any screen
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, 
			new Vector3(screenWidth, screenHeight, 1)); 
    }

    void Highlight ()
    {
    	GUI.contentColor = _highlight;
    }

    void ResetHighlight ()
    {
    	GUI.contentColor = Color.white;
    }
}