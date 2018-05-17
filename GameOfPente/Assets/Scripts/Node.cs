using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{


	SpriteRenderer spriteRenderer = null;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		Color = eColor.EMPTY;
	}
	
	private eColor color;

	public eColor Color {get {return color;} set {color = value; SetSpriteColor(value);}}


	private void SetSpriteColor(eColor color)
	{
		switch (color)
		{
			case eColor.WHITE:
				spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				break;
			case eColor.BLACK:
				spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
				break;
			case eColor.W_HOVER:
				spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				break;
			case eColor.B_HOVER:
				spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
				break;
			case eColor.EMPTY:
				spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;
		}
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

	private void OnMouseEnter()
	{
		if (Color == eColor.EMPTY)
		{
			eColor curPlayerColor = eColor.EMPTY;
			switch(TurnManager.Instance.playerTurn)
			{
				case PlayerTurn.PLAYER1:
					curPlayerColor = eColor.B_HOVER;
					break;
				case PlayerTurn.PLAYER2:
					curPlayerColor = eColor.W_HOVER;
					break;
			}
			Color = curPlayerColor;
		}	
	}
	
	private void OnMouseExit() 
	{
		if(Color == eColor.W_HOVER || Color == eColor.B_HOVER)
			Color = eColor.EMPTY;
	}

	void OnMouseDown() 
	{
		if (Color == eColor.W_HOVER || Color == eColor.B_HOVER)
		{
			eColor curPlayerColor = eColor.EMPTY;
			switch(TurnManager.Instance.playerTurn)
			{
				case PlayerTurn.PLAYER1:
					curPlayerColor = eColor.BLACK;
					break;
				case PlayerTurn.PLAYER2:
					curPlayerColor = eColor.WHITE;
					break;
			}
			Color = curPlayerColor;
			TurnManager.Instance.NextTurn();
		}	
	}

}
