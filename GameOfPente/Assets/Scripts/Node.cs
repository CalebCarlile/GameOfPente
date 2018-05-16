using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public enum eColor
	{
		WHITE,
		BLACK,
		EMPTY
	}

	public enum Direction
	{
		NORTH,
		EAST,
		SOUTH,
		WEST
	}

	public eColor Color {get; set;}

	public Node NorthNode;
	public Node EastNode;
	public Node SouthNode;
	public Node WestNode;

	public Node GetNode(Direction dir)
	{
		switch (dir)
		{
			case Direction.NORTH:

			break;
			case Direction.EAST:

			break;
			case Direction.SOUTH:

			break;
			case Direction.WEST:

			break;
		}
		return null;
	}

	public void SetNode(Direction dir, Node node)
	{

	}

}
