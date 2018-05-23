using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehavior : MonoBehaviour
{

	public SpriteRenderer spriteRenderer = null;
    [SerializeField] public Node node;

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
				spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
				break;
			case eColor.B_HOVER:
				spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
				break;
			case eColor.EMPTY:
				spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;
		}
	}

    public void UpdateNode()
    {
        if(node.color != color)
        {
            SetSpriteColor(node.color);
            color = node.color;
        }
    }

	private void OnMouseEnter()
	{
		if (Color == eColor.EMPTY)
		{
			eColor curPlayerColor = eColor.EMPTY;
			switch(TurnManager.Instance.playerTurn)
			{
				case PlayerTurn.BLACK_PLAYER1:
					curPlayerColor = eColor.B_HOVER;
					break;
				case PlayerTurn.WHITE_PLAYER2:
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
				case PlayerTurn.BLACK_PLAYER1:
					curPlayerColor = eColor.BLACK;
					break;
				case PlayerTurn.WHITE_PLAYER2:
					curPlayerColor = eColor.WHITE;
					break;
			}
			Color = curPlayerColor;
            node.color = curPlayerColor;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<BoardManagerBehavior>().CheckBoard(this);
			TurnManager.Instance.NextTurn();
        }
    }

}
