using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {

	public int LineZ = 0;

	public GameObject Line;

	private GameObject currentLine;

	List<GameObject> toDestroy;

	bool down;
	float sizeX;
	float sizeY;
	private Vector3 startWorldMousePoint;
	// Use this for initialization
	void Start () {
		down = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (down)
		{
			Vector3 currentWorldMousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			currentWorldMousePoint.z = LineZ;
			float dx = currentWorldMousePoint.x - startWorldMousePoint.x;
			float dy = currentWorldMousePoint.y - startWorldMousePoint.y;

			float distance = Vector3.Distance (currentWorldMousePoint, startWorldMousePoint);

			if (distance == 0)
			{
				return; 
			} 

			float a = -angle (startWorldMousePoint, currentWorldMousePoint);
 
			currentLine.transform.localScale = new Vector3 (1 / sizeX, distance / sizeY, currentLine.transform.localScale.z);
			currentLine.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, a));


			if (needNewLine ())
				newLine ();

		}
	
		if (Input.GetMouseButtonDown (0))
		{
			toDestroy = new List<GameObject> (); 
			newLine ();
		}

		if (Input.GetMouseButtonUp (0))
		{
			down = false;

			print (toDestroy.Count);

			string s = "";
			GameObject lineB4 = null;
			foreach (GameObject line in toDestroy)
			{
				Destroy (line);

				if (s == "")
				{
					s += "A: ";
					lineB4 = line;
					continue;
				}


				s += string.Format("{0:0.##} ",  angle (lineB4.transform.position, line.transform.position));


				lineB4 = line;

			}

			print (s);

		}

	}

	private const float NEW_LINE_DISTANCE = 0.5f;
	private bool needNewLine()
	{
		Vector3 currentWorldMousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		currentWorldMousePoint.z = LineZ;

		if (Vector3.Distance (currentWorldMousePoint, startWorldMousePoint) >= NEW_LINE_DISTANCE)
			return true;
		return false;


	}


	private void newLine()
	{
		startWorldMousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		startWorldMousePoint .z = LineZ;
		currentLine = Instantiate (Line, startWorldMousePoint , Quaternion.identity);
		down = true;

		SpriteRenderer spriteRenderer = Line.GetComponent<SpriteRenderer> (); 
		sizeX = spriteRenderer.bounds.size.x;
		sizeY = spriteRenderer.bounds.size.y;

		currentLine.transform.localScale = new Vector3 (1 / sizeX, 0, currentLine.transform.localScale.z);
		toDestroy.Add (currentLine);
	}


	private float angle(Vector3 start, Vector3 end)
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
