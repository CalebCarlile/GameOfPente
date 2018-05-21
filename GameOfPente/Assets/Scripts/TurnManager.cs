using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
    public int captureCount;
}

public class TurnManager : Singleton<TurnManager> 
{

    public Player p1;
    public Player p2;
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
