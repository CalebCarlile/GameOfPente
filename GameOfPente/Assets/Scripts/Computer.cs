using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour 
{

	private static BoardManagerBehavior boardBehavior;
	private static BoardManager boardManager;

	public static void LinkBoard(BoardManagerBehavior boardBehav, BoardManager boardMan)
	{
		boardBehavior = boardBehav;
		boardManager = boardMan;
	}

	public static NodeBehavior MakeMove()
	{
		boardBehavior.Wait();
		bool valid = false;
		while(!valid)
		{
			int x = Random.Range(0, boardBehavior.boardManager.boardSize);
			int y = Random.Range(0, boardBehavior.boardManager.boardSize);
			NodeBehavior node = boardBehavior.NodeBehaviors[x, y].GetComponent<NodeBehavior>();
			if(boardManager.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 4, node.node, eColor.WHITE))
			{
				valid = true;
				node.Color = eColor.W_HOVER;
			}
		}
		return null;
	}
}
