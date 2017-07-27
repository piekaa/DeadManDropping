using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LineAnalyzerByAngle :  ILineAnalyzer {

	private const float str8LineAngleLimit = 10;

	public LineInfo Analyze (List<Vector2> points)
	{ 
		LineInfo result = new LineInfo ();

		if (points.Count < 3)
		{
			result.type = LineType.Unknown;
			return result;
		}


		List<float> angles = new List<float> ();
		bool first = true;
		Vector2 prev = new Vector2();

		foreach( Vector2 point in points )
		{
			if (first == true)
			{
				first = false;
				prev = point;
				continue;
			}

			angles.Add (Utils.Angle (prev, point));
			prev = point;
		} 

		angles.ForEach ((e) =>
		{
			while (e < 0)
				e += 360;
			e %= 360;
		});
 
		List<float> angleDiffs = new List<float> ();

		first = true;
		float prevAngle= 0;
		foreach (float angle in angles)
		{
			if (first)
			{
				prevAngle = angle;
				first = false;
				continue;
			}

			angleDiffs.Add( angleDiff( prevAngle, angle ));

			prevAngle = angle;
		}
			

		float average = angleDiffs.Average ();
 

		if (average > str8LineAngleLimit)
			result.type = LineType.ArcClockwise;
		else if (average < -str8LineAngleLimit)
			result.type = LineType.ArcCounterClockwise;
		else
			result.type = LineType.Straight;
 

		return result;

	}


	private float angleDiff(float a1, float a2)
	{
		float result = a2 - a1;

		if (result > 180)
			result = 360 - result;

		if (result < -180)
			result = -360 - result;

		return result;
	}

}
