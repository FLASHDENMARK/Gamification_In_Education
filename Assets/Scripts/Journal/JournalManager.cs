using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Seperate into more functions!

// Manages the main behaviour of the journal
class JournalManager : MonoBehaviour 
{
	// A list of all subjects
	List<Subject> subjects = new List<Subject>();
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

	Subject CurrentSubject
	{
		get { return subjects[_selection]; }
	}

	Topic CurrentTopic 
	{
		get { return CurrentSubject.Entries[CurrentSubject.Selection]; }
	}
	
	List<Topic> Topics
	{
		get { return CurrentSubject.Entries; }
	}


	// Adds a new subject to the list of subjects
	public void AddSubject (Subject subject)
	{
		subjects.Add(subject);
	}

	public Texture2D bastian;

	// Is called once when the application starts
	void Start () 
	{
		//HowToAddTopic();
		CreateIntro();
		CreateMathematics();
		CreatePhysics();
	}

	void HowToAddTopic ()
	{
		// Create a new subject if the subject doesn't already exist
		Subject newSubject = new Subject("New Subject");
		// Add the new subject to a list of all subjects
		AddSubject(newSubject);
		// Create a new topic
		Topic newTopic = new Topic("New Topic");
		// Add the topic to the subject
		newSubject.AddTopic(newTopic);

		// Add text(JournalEntry) / images(JournalEntryImage) to the topic
		newTopic.AddEntry(new JournalEntry("This is a piece of text for the topic: New Topic", "This is a label for this text (optional)"));
		newTopic.AddEntry(new JournalEntryImage(new Texture2D(100, 100), "This is a label for this image"));
		// The above can be done in any order ot matter how many entries
	}

	void CreateIntro ()
	{
        Subject intro = new Subject("Intro");
        AddSubject(intro);

        Topic aboutThisJournal = new Topic("About this journal");
        intro.AddTopic(aboutThisJournal);

        string aboutThisJournalText =
        "<b>This journal belongs to Science Professor Jameson</b>"
        + "\n\nThis journal contains the discoveries I have done, through various experiments."
        + " The finds are divided into chapters of their respective subjects."
        + "\n\nIf you are to find this book, please return it to me."
        + "\n\n<i>-- Prof. Jameson</i>";

        // Adds an entry to the topic. 
        aboutThisJournal.AddEntry(new JournalEntry(aboutThisJournalText));
	}

	void CreateMathematics ()
	{
        Subject mathematics = new Subject("Mathematics");
        AddSubject(mathematics);

        Topic orderOfOperations = new Topic("Order of operations");
        mathematics.AddTopic(orderOfOperations);

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

        orderOfOperations.AddEntry(new JournalEntry(orderOfOperationsText));

        Topic geometry = new Topic("Geometry");
        mathematics.AddTopic(geometry);

		string geometryText = "Through years of research I have finally cracked the "
		+ "relationship between geometry and their area and volume - how exciting! "
		+ "\n\nCalculating the area of geometrical figures seems easier than finding the volume."
		+ "This is because area is the '<i>size of a flat surface</i>', whereas volume is "
		+ "the '<i>amount of space inside an object</i>'."
		+ "\n\n<b>Area</b>"
		+ "\n\n";

        geometry.AddEntry(new JournalEntry(geometryText));
	}

	void CreatePhysics ()
	{
		Subject physics = new Subject("Physics");
		AddSubject(physics);

        Topic fireTriangle = new Topic("Fire Triangle");
        physics.AddTopic(fireTriangle);

        string fireTriangleText =
        "I have spend the entire day, analyzing the behaviour of fire, and I think I have figured it out. "
        + "It seems that the ability to create a fire is based on three primary factors. "
        + "I have not been able to produce a fire without these components, so they seem essential in creating a fire. "
        + "\n\nFirstly to create a fire, I need something that can serve as a fuel, something that can burn. \n\n"
        + "I have also found that creating a fire in an oxygenless environment is impossible. It seems that oxygen is a key "
        + "component too. \n\nLastly I have found that the reaction, that is fire, can be started by raising the fuel to it's"
        + " ignition temperature, as long as the other two components are present.\n\n"
        + "I am fairly certain this information will come in handy at some point."
        + "\n\n <i>-- Prof. Jameson</i>";

    	fireTriangle.AddEntry(new JournalEntry(fireTriangleText, "Day: 34 - Analysis of fire"));
        fireTriangle.AddEntry(new JournalEntryImage(bastian, "This is bastian, he is a faggot"));
        fireTriangle.AddEntry(new JournalEntry(fireTriangleText, "Test title"));

        Topic waterDistillation = new Topic("Water Distillation");
        physics.AddTopic(waterDistillation);

        string waterDistillationText =
        "<b>\tDay: 37 - Distilling of saltwater</b>"
        + "\n\nI have though of a way to make drinkable water! I just need a container to hold the water "
        + "then I can boil it and cool the steam to turn it into drinkable water. "
        + "\n\nI've made an equation to make it easier to remember "
        + "\n<b> E = m * c * ΔT</b>";

        waterDistillation.AddEntry(new JournalEntry(waterDistillationText));
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
		// Draw all the subjects
        for (int i = 0; i < subjects.Count; i++)
        {
			if (i == _selection)
			{
				Highlight();
			}

        	if (GUI.Button(new Rect(100, 30 + 45 * i, 120, 30), subjects[i].Name))
        	{
        		ResetScrollView();
        		_selection = i;
        	}

    		ResetHighlight();
        }

        // Draw all the topic under the current subject
        for (int i = 0; i < Topics.Count; i++)
        {
			if (i == subjects[_selection].Selection)
			{
				Highlight();
			}

        	if (GUI.Button(new Rect(240, 30 + 45 * i, 120, 30), Topics[i].Name))
        	{
        		ResetScrollView();
        		subjects[_selection].Selection = i;
        	}

        	ResetHighlight();
        }	

        windowRect = GUI.Window(0, windowRect, TheoryUIWindow, CurrentTopic.Name);
	}

	Vector2 scrollPosition;

	float totalHeight = 0;
	// Draws the currently selected subject to the screen
    void TheoryUIWindow (int windowID) 
    {	
    	float width = windowRect.width-30;
    	// The XY position and XY width of a "scroll view", which allows us to scroll 
    	// through the text if it exceeds its boundaries
    	Rect scrollPosAndSize = new Rect(10, 20, width+20, 375);
    	// The current "scroll position" (how much we have scrolled up/down, left/right)
    	Rect scrollView = new Rect(0, 0, width, totalHeight);
 		totalHeight = 0;

    	// Draw a scroll view
	 	scrollPosition = GUI.BeginScrollView(scrollPosAndSize, scrollPosition, scrollView);
	 		List<JournalEntryBase> journalEntries = CurrentTopic.Entries;

	        for (int i = 0; i < journalEntries.Count; i++)
	        {
	        	GUIContent g = journalEntries[i].Content;
	 			float height = GUIHeight(g, width);

	 			// Are we about to draw an image to the screen?
	        	if (g.image)
	        	{
	        		// Aligns the image to the center
	        		GUI.skin.label.alignment = TextAnchor.UpperCenter;
	        		// Draws the image
	        		GUI.Label(new Rect(0, totalHeight, width, height), g);
	        		// Draws the label for the image
	        		GUI.Label(new Rect(0, totalHeight + height, width, height), "<i>" + g.tooltip + "</i>");
	        		// Reset the alignment
	        		GUI.skin.label.alignment = TextAnchor.UpperLeft;
	        		// Increment the height of the window
	        		totalHeight += GUIHeight(new GUIContent(g.tooltip), width);
	        	}
	        	// We are about to draw a text
	        	else
	        	{
	        		if (!string.IsNullOrEmpty(g.tooltip))
	        		{
	        			GUI.skin.label.alignment = TextAnchor.UpperCenter;
	        			GUI.Label(new Rect(0, totalHeight, width, height), "<b>" + g.tooltip + "</b>");
	        			GUI.skin.label.alignment = TextAnchor.UpperLeft;
	        			totalHeight += GUIHeight(new GUIContent(g.tooltip), width);
	        		}

	        		GUI.Label(new Rect(0, totalHeight, width, height), g);
	        	}

	        	totalHeight += height;
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

    void ResetScrollView ()
    {
    	totalHeight = 0;
    }

    float GUIHeight (GUIContent g, float width)
    {
    	return GUI.skin.label.CalcHeight(g, width);
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