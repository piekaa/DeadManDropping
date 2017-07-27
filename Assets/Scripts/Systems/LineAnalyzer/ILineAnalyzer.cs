using UnityEngine;
using System.Collections.Generic;
public enum LineType
{
	Unknown,
	Straight,
	ArcClockwise,
	ArcCounterClockwise
}


public class LineInfo
{
	public LineType type;
	public float angle;
}


public interface ILineAnalyzer 
{
	LineInfo Analyze (List<Vector2> points);
}
