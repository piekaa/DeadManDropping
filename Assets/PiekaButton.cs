using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiekaButton : Pieka{

	public string eventId;

	// Use this for initialization
	void Start () {

		Button button = GetComponent<Button> ();

		button.onClick.AddListener (fireEvent);
	}

	void fireEvent()
	{
		SEventSystem.FireEvent (eventId);
	}
}
