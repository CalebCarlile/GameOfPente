using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVisualizer : MonoBehaviour 
{
	// [SerializeField] int dimensions;
	// [SerializeField] float distanceBetween;
	[SerializeField] Color lineColor;
	[SerializeField] GameObject empty;

	List<LineRenderer> boardLines = new List<LineRenderer>();
	
	
	// Use this for initialization
	public void Initialize (int dimensions, float distanceBetween) 
	{

		for(int x = 0; x < dimensions; ++x)
		{			
			
			GameObject go = Instantiate(empty, gameObject.transform);
			LineRenderer lr = go.AddComponent<LineRenderer>() as LineRenderer;
			lr.positionCount = 2;
			lr.SetPosition(0, new Vector3( -(dimensions * distanceBetween) / 2 + distanceBetween / 2, x * distanceBetween - (dimensions * distanceBetween) / 2 + distanceBetween / 2, 0.0f));
			lr.SetPosition(1, new Vector3(((dimensions * distanceBetween) / 2) - distanceBetween / 2, x * distanceBetween -(dimensions * distanceBetween) / 2 + distanceBetween / 2, 0.0f));
			lr.startWidth = 0.09f;
			lr.endWidth = 0.09f;
			boardLines.Add(lr);			
		}

		for(int y = 0; y < dimensions; ++y)
		{			
			GameObject go = Instantiate(empty, gameObject.transform);
			LineRenderer lr = go.AddComponent<LineRenderer>() as LineRenderer;
			lr.positionCount = 2;
			lr.SetPosition(0, new Vector3(y * distanceBetween -(dimensions * distanceBetween) / 2 + distanceBetween / 2, 0 -(dimensions * distanceBetween) / 2 + distanceBetween / 2, 0.0f));
			lr.SetPosition(1, new Vector3(y * distanceBetween -(dimensions * distanceBetween) / 2 + distanceBetween / 2, (dimensions * distanceBetween) - distanceBetween / 2 -(dimensions * distanceBetween) / 2, 0.0f));
			lr.startWidth = 0.09f;
			lr.endWidth = 0.09f;
			boardLines.Add(lr);			
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
