using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;

	public PlayerType playerType;
    public int captureCount;
}

public class TurnManager : Singleton<TurnManager> 
{

	void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (ms_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ms_instance = this;
        }
    }

    public Player p1 = new Player();
    public Player p2 = new Player();
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
