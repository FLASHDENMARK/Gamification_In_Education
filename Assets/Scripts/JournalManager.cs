using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Reset the scroll view
// Image labels
// Center images
// Seperate into more functions!
// Store expressions as temp variables
// Use same names across files

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
	// Show the journal or not (statically accessible)
	public static bool ShowJournal;
	// The Keycode (button input) to toggle the journal on/off
	KeyCode _showKey = KeyCode.Tab;
	// The color of the highlighted GUI 
	Color _highlight = Color.grey;

	// Adds a new subject to the list of subjects
	public void AddSubject (JournalMenu JournalMenu)
	{
		subjects.Add(JournalMenu);
	}

	public Texture2D bastian;

	// Is called once when the application starts
	void Start () 
	{
		CreateIntro();
		CreateMathematics();
		CreatePhysics();
	}

	void CreateIntro ()
	{
		// Creates a new subject
        JournalMenu intro = new JournalMenu("Intro");
        // Creates a new topic under the above subject
        JournalMenuEntry aboutThisJournal = new JournalMenuEntry("About this journal");

        string aboutThisJournalText =
        "<b>This journal belongs to Science Professor Jameson</b>"
        + "\n\nThis journal contains the discoveries I have done, through various experiments."
        + " The finds are divided into chapters of their respective subjects."
        + "\n\nIf you are to find this book, please return it to me."
        + "\n\n<i>-- Prof. Jameson</i>";

        // Adds an entry to the topic. 
        aboutThisJournal.AddJournalEntry(new JournalEntry(aboutThisJournalText));
        // Adds the topic to the subject
        intro.AddMenuEntry(aboutThisJournal);
        // Adds the subject to a list of subjects
        AddSubject(intro);
	}

	void CreateMathematics ()
	{
        JournalMenu mathematics = new JournalMenu("Mathematics");
        JournalMenuEntry orderOfOperations = new JournalMenuEntry("Order of operations");

        string orderOfOperationsText = "It seems that math can be misleading at times."
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

        orderOfOperations.AddJournalEntry(new JournalEntry(orderOfOperationsText));
        mathematics.AddMenuEntry(orderOfOperations);
        AddSubject(mathematics);
	}

	void CreatePhysics ()
	{
		JournalMenu physics = new JournalMenu("Physics");
        JournalMenuEntry fireTriangle = new JournalMenuEntry("Fire Triangle");

        string fireTriangleText =
        "<b>\tDay: 34 - Analysis of fire</b>"
        + "\n\nI have spend the entire day, analyzing the behaviour of fire, and I think I have figured it out. "
        + "It seems that the ability to create a fire is based on three primary factors. "
        + "I have not been able to produce a fire without these components, so they seem important to creating a fire. "
        + "\n\nFirstly to create a fire, I need something that can serve as a fuel, something that can burn. \n\n"
        + "I have also found that creating a fire in an oxygenless environment is impossible. It seems that oxygen is a key "
        + "component too. \n\nLastly I have found that the reaction, that is fire, can be started by raising the fuel to it's"
        + " ignition temperature, as long as the other two components are present.\n\n"
        + "I am fairly certain this information will come in handy at some point."
        + "\n\n <i>-- Prof. Jameson</i>";

    	fireTriangle.AddJournalEntry(new JournalEntry(fireTriangleText));
        fireTriangle.AddJournalEntry(new JournalEntryImage(bastian, "Image label goes here"));
        physics.AddMenuEntry(fireTriangle);

        JournalMenuEntry waterDistillation = new JournalMenuEntry("Water Distillation");

        string waterDistillationText =
        "<b>\tDay: 37 - Distilling of saltwater</b>"
        + "\n\nI have though of a way to make drinkable water! i just need a container to hold the water "
        + "then i can boil it and cool the steam to turn it into drinkable water. "
        + "\n\nI've made an equation to make it easier to remember "
        + "\n<b> E = m * c * ΔT</b>";

        waterDistillation.AddJournalEntry(new JournalEntry(waterDistillationText));
        physics.AddMenuEntry(waterDistillation);
        AddSubject(physics);
	}

	// Called every frame
	void Update ()
	{
		if (Input.GetKeyDown(_showKey))
		{
			ShowJournal = !ShowJournal; 
		}
	}

	// Called every frame and draws UI elements on screen
	void OnGUI ()
	{
		ScaleToScreenSize();

        GUI.backgroundColor = new Color(0, 0, 0, 1);

        // Let the user know how to toggle the Journal on and off
        GUI.Box(new Rect(0, 450, 280, 30), "");
        GUI.Label(new Rect(10, 455, 350, 30), 
			"Press " + _showKey.ToString() + " to " + (ShowJournal? "hide" : "show") + " the Professor's Journal");

        // Return if the journal shouldn't be show
        if (!ShowJournal) {
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
        for (int i = 0; i < subjects.Count; i++)
        {
			if (i == _selection)
			{
				Highlight();
			}

        	if (GUI.Button(new Rect(100, 30 + 45 * i, 120, 30), subjects[i].Headline))
        	{
        		_selection = i;
        	}

    		ResetHighlight();
        }

        for (int i = 0; i < subjects[_selection].menuEntries.Count; i++)
        {
			if (i == subjects[_selection].Selection)
			{
				Highlight();
			}

        	if (GUI.Button(new Rect(240, 30 + 45 * i, 120, 30), subjects[_selection].menuEntries[i].Topic))
        	{
        		subjects[_selection].Selection = i;
        	}

        	ResetHighlight();
        }	

        windowRect = GUI.Window(0, windowRect, TheoryUIWindow, subjects[_selection].menuEntries[subjects[_selection].Selection].Topic);
	}

	Vector2 scrollPosition;

	float height = 0;
	// Draws the currently selected subject to the screen
    void TheoryUIWindow (int windowID) 
    {	
    	float width = windowRect.width-30;
    	// The XY position and XY width of a "scroll view", which allows us to scroll 
    	// through the text if it exceeds its boundaries
    	Rect scrollPosAndSize = new Rect(10, 20, width+20, 375);
    	// The current "scroll position" (how much we have scrolled up/down, left/right)
    	Rect scrollView = new Rect(0, 0, width, height);

    	// Draw a scroll view
	 	scrollPosition = GUI.BeginScrollView(scrollPosAndSize, scrollPosition, scrollView);

        	height = 0;
	        for (int i = 0; i < subjects[_selection].menuEntries[subjects[_selection].Selection].journalEntries.Count; i++)
	        {
	        	GUIContent g = subjects[_selection].menuEntries[subjects[_selection].Selection].journalEntries[i].Content;

	        	// Improve!
	        	/*if (g.image != null)
	        	{
	        		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
	        		GUI.Label(new Rect(0, height + GUI.skin.label.CalcHeight(g, width) / 2, width, GUI.skin.label.CalcHeight(g, width)), g.tooltip);
	        		GUI.skin.label.alignment = TextAnchor.UpperLeft;
	        	}*/
	        		
	        	GUI.Label(new Rect(0, height, width, GUI.skin.label.CalcHeight(g, width)), g);
    	    	// Calculates the height of the text / images being drawn on the screen. 
	        	height += GUI.skin.label.CalcHeight(g, width);
	        }

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