﻿using UnityEngine;
using System.Collections;

public interface IClickable 
{
	void OnClick();
	void OnConfirmedOrDenied(bool b);
}