using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffectorController : Pieka{

	private AreaEffector2D areaEffector;

	// Use this for initialization
	void Start () {
		areaEffector = GetComponent<AreaEffector2D> ();
	}

	[OnEvent(EventIDs.Gesture.Made) ]
	void disableEffector()
	{
		areaEffector.enabled = false;
	}

	[OnEvent(EventIDs.Game.Reset)]
	void enableEffector()
	{
		areaEffector.enabled = true;
	}



	 
}
