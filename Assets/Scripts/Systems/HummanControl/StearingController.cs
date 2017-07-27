using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StearingController : Pieka {

	public LineDrawer LineDrawer;
	public EffectorPlacer EffectorPlacer;
	ILineAnalyzer lineAnalyzer;

	void Start()
	{
		lineAnalyzer = Core.Instance.LineAnalyzer;
		LineDrawer.NewLineEvent += onNewLine;
	}


	private void onNewLine(List<Vector2> points)
	{
		LineInfo lineInfo = lineAnalyzer.Analyze (points);

		if (lineInfo.type != LineType.Unknown)
		{
			EffectorPlacer.PlaceEffector (lineInfo, points);
			FireEvent (EventIDs.Gesture.Made);
		}

	}
 
}
