using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public BoardManager boardManager;
	public SpriteRenderer spriteRenderer = null;
    public int x;
    public int y;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public eColor Color {get {return Color;} set {Color = value; SetSpriteColor(value);}}


	private void SetSpriteColor(eColor color)
	{

	}

	public Node GetNode(Direction dir)
	{
        switch (dir)
        {
            case Direction.EAST:
                return boardManager.GetNode(x + 1, y);
            case Direction.NORTH:
                return boardManager.GetNode(x, y - 1);
            case Direction.NORTHEAST:
                return boardManager.GetNode(x + 1, y - 1);
            case Direction.NORTHWEST:
                return boardManager.GetNode(x - 1, y - 1);
            case Direction.SOUTH:
                return boardManager.GetNode(x, y + 1);
            case Direction.SOUTHEAST:
                return boardManager.GetNode(x + 1, y + 1);
            case Direction.SOUTHWEST:
                return boardManager.GetNode(x - 1, y + 1);
            case Direction.WEST:
                return boardManager.GetNode(x - 1, y);
        }
        return null;
	}

}
