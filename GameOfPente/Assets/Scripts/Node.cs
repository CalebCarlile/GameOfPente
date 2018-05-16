using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{


	SpriteRenderer spriteRenderer = null;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

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

	public eColor Color {get {return Color;} set {Color = value; SetSpriteColor(value);}}


	private void SetSpriteColor(eColor color)
	{

	}


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
