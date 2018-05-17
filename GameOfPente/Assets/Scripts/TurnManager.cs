using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : Singleton<TurnManager> 
{

	public string player1Name;
	public string player2Name;
	public PlayerTurn playerTurn = PlayerTurn.BLACK_PLAYER1;

	public void NextTurn()
	{
		switch(playerTurn)
		{
			case PlayerTurn.BLACK_PLAYER1:
				playerTurn = PlayerTurn.WHITE_PLAYER2;
				break;
			case PlayerTurn.WHITE_PLAYER2:
				playerTurn = PlayerTurn.BLACK_PLAYER1;
				break;
		}
	}
}
