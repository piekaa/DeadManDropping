using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core {

	public ILineAnalyzer LineAnalyzer;

	public static Core Instance = new Core ();


	private Core()
	{
		LineAnalyzer = new LineAnalyzerByAngle ();
	}




}
