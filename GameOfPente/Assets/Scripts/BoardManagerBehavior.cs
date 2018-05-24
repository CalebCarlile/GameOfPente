using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoardManagerBehavior: MonoBehaviour
{
	public GameObject NodeBehaviorTemplate = null;
	public GameObject[,] NodeBehaviors;
    public BoardManager boardManager;
    public Notification eyeCandy;
    public Color triaColor;
    public Color tesseraColor;
    public Color winColor;
    public Color captureColor;

    [SerializeField] Camera m_camera = null;
    public int boardSize = 19;


    private float distanceBetween = 1.0f;

    void Start()
    {
        boardSize = MenuUtility.boardSize;
        boardManager = new BoardManager();
        Computer.LinkBoard(this, boardManager);
        Init(boardSize);
    }

	public void Init(int size, bool isLoad = false)
	{
        //distanceBetween = ((0.00178571f  * Mathf.Pow(boardSize, 2)) - (0.135714f * boardSize) + 3.07679f);
        float camSize = ((float)boardSize - 9) / 30;
        m_camera.orthographicSize = Mathf.Lerp(5, 20, camSize);
        GetComponent<BoardVisualizer>().Initialize(boardSize, distanceBetween);
		CreateNodeBehaviors(size, isLoad);
        boardSize = size;
	}

	private void CreateNodeBehaviors(int size, bool isLoad = false)
	{
        //float nodeSize = ((float)boardSize - 9) / 30;
        //nodeSize = Mathf.Lerp(0.75f, 0.15f, nodeSize);
        if (!isLoad)
        {
            NodeBehaviors = new GameObject[boardSize, boardSize];
            boardManager.Init(boardSize);
        }
        float curx, cury;
        curx = 0 - (boardSize / 2 * distanceBetween);
        cury = 0 + (boardSize / 2 * distanceBetween);
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                GameObject node = null;
                if (isLoad)
                {
                    node = NodeBehaviors[x, y];
                } else {
                    node = Instantiate(NodeBehaviorTemplate);
                }
                NodeBehavior n = node.GetComponent<NodeBehavior>();
                n.node = boardManager.nodes[x, y];
                n.node.x = x;
                n.node.y = y;
                if (isLoad)
                {
                    n.Color = boardManager.nodes[x, y].color;
                }
                NodeBehaviors[x, y] = node;
                node.transform.position = new Vector3(curx, cury, 0.0f);
                cury -= distanceBetween;
            }
            curx += distanceBetween;
            cury = 0 + (boardSize / 2 * distanceBetween);
        }
	}



    public void CheckBoard(NodeBehavior last)
    {
        TurnManager turnManager = TurnManager.Instance;
        if (boardManager.WonGame(last.node))
        {
            print(last.Color + " WON!");
            eyeCandy.Notify(last.transform.position, last.Color + " WON!", 60, 1, Vector2.up * 1, winColor);
            SceneManager.LoadScene("UIProto");
            return;
        }
        List<Node> captures = boardManager.FindCaptures(last.node);
        if (captures.Count > 0)
        {
            eyeCandy.Notify(last.transform.position, "Capture!", 30, 1, Vector2.up * 2, captureColor);
        }
        foreach (Node capture in captures)
        {
            capture.color = eColor.EMPTY;
            switch(turnManager.playerTurn)
            {
                case PlayerTurn.BLACK_PLAYER1:
                    turnManager.p1.captureCount++;
                    break;
                case PlayerTurn.WHITE_PLAYER2:
                    turnManager.p2.captureCount++;
                    break;
            }
        }
        switch(turnManager.playerTurn)
        {
            case PlayerTurn.BLACK_PLAYER1:
                if(turnManager.p1.captureCount >= 10)
                {
                    print(last.Color + " WON!");
                }
                break;
            case PlayerTurn.WHITE_PLAYER2:
                if(turnManager.p2.captureCount >= 10)
                {
                    print(last.Color + " WON!");
                }
                break;
        }
        if (boardManager.TesseraCreated(last.node))
        {
            print("TESSERA!");
            eyeCandy.Notify(last.transform.position, "Tessera!", 40, 2, Vector2.up * 3, tesseraColor);

        }
        else if (boardManager.TriaCreated(last.node))
        {
            print("TRIA!");
            eyeCandy.Notify(last.transform.position, "Tria!", 30, 1, Vector2.up * 2, triaColor);
        }

        for(int i = 0; i < boardSize; ++i)
        {
            for(int j = 0; j < boardSize; ++j)
            {
                NodeBehaviors[i, j].GetComponent<NodeBehavior>().UpdateNode();
            }
        }
    }

    public void Save()
    {
        string savePath = EditorUtility.SaveFilePanel("Save Game", "", "Game", "pente");
        if (savePath != "")
        {
            boardManager.SaveNodesToFile(savePath);
        }
    }

    public void Load()
    {
        string loadPath = EditorUtility.OpenFilePanel("Load Game", "", "pente");
        if (loadPath != "")
        {
            boardManager.LoadNodesFromFile(loadPath);
        }
        Init(boardManager.boardSize, true);
    }

    public void Wait(float time = 0.5f)
	{
		StartCoroutine(WaitTime(time));
	}

	private IEnumerator WaitTime(float duration)
	{
		float remaining = duration;
		while(remaining > 0)
		{
			remaining -= Time.deltaTime;
			yield return null;
		}
        foreach(GameObject node in NodeBehaviors)
        {
            if(node.GetComponent<NodeBehavior>().Color == eColor.W_HOVER)
            {
                node.GetComponent<NodeBehavior>().Place(eColor.WHITE);
            }
        }
		TurnManager.Instance.NextTurn();
	}

}
