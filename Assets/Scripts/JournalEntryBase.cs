using System;
using System.Collections.Generic;

class JournalEntryBase 
{
    public JournalEntryBase (string headline) : this (headline, "") { }

    public JournalEntryBase (string headline, string body)
    {
        this._headline = headline;
        this._body = body;
    }

	string _headline = "";
    public virtual string Headline
    {
        get { return _headline; }
        private set
        {
            if (value == "")
                throw new ArgumentNullException();
            else
                _headline = value;
        }
    }    

	string _body = "";
    public virtual string Body
    {
        get { return _body; }
        private set
        {
            if (value == "")
                throw new ArgumentNullException();
            else
                _body = value;
        }
    }
}
