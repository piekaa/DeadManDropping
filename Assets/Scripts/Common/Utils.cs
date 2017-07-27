using UnityEngine;

public class Utils 
{
	public static float Angle(Vector3 start, Vector3 end)
	{

		Vector2 v1 = new Vector2 (start.x, start.y);
		Vector2 v2 = new Vector2 (end.x, end.y);
		float a = v2.x - v1.x;
		float b = v2.y - v1.y;
		float c = Vector2.Distance(v1, v2);

		float acos = Mathf.Acos (b / c) * 180 / Mathf.PI;

		float result;
		if (a > 0)
		{
			result = acos;
		} else
		{
			result = 360 - acos;
		}
		return result;
	}
}
