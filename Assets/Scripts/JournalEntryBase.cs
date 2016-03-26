using System.Collections.Generic;

// Abstract class allows us to "force" some implementation on deriving classes
abstract class JournalEntryBase 
{
	string _headline = "";
	string _body = "";

	// Property
	public virtual string Headline
	{
		get
        {
            return _headline;
        }
        set
        {
            _headline = value;

            if (value == "")
            {
            	// Throw custom exception CannotBeNullException
            }
        }
	}

	// Property
    public virtual string Body
    {
        get
        {
            return _body;
        }
        set
        {
            _body = value;

            if (value == "")
            {
            	// Throw custom exception CannotBeNullException
            }
        }
    }

	// Constructor
	public JournalEntryBase (string headline) : this (headline, "") {}
	// Constructor
	public JournalEntryBase (string headline, string body)
	{
		this._headline = headline;
		this._body = body;
	}

	// Force implemention of GetEntries
	public abstract List<JournalEntryBase> GetEntries ();
	// Force implementation of Select
	public abstract void Select(int selection);

	// Override of ToString
	/*public override string ToString ()
	{
		return _headline + " " + _body;
	}*/
}
