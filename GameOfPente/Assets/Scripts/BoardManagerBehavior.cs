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
        Init(boardSize);
    }

	public void Init(int size)
	{
        //distanceBetween = ((0.00178571f  * Mathf.Pow(boardSize, 2)) - (0.135714f * boardSize) + 3.07679f);
        float camSize = ((float)boardSize - 9) / 30;
        m_camera.orthographicSize = Mathf.Lerp(5, 20, camSize);
        GetComponent<BoardVisualizer>().Initialize(boardSize, distanceBetween);
		CreateNodeBehaviors(size);
        boardSize = size;
	}

	private void CreateNodeBehaviors(int size)
	{
        //float nodeSize = ((float)boardSize - 9) / 30;
        //nodeSize = Mathf.Lerp(0.75f, 0.15f, nodeSize);
        NodeBehaviors = new GameObject[boardSize, boardSize];
        boardManager.Init(boardSize);
        float curx, cury;
        curx = 0 - (boardSize / 2 * distanceBetween);
        cury = 0 + (boardSize / 2 * distanceBetween);
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                GameObject node = Instantiate(NodeBehaviorTemplate);
                NodeBehavior n = node.GetComponent<NodeBehavior>();
                n.node = boardManager.nodes[x, y];
                n.node.x = x;
                n.node.y = y;

                if(boardManager.nodes[x,y] == null)
                {
                    print("Not initialized");
                }
                n.node.color = eColor.EMPTY;
                NodeBehaviors[x, y] = node;

                boardManager.nodes[x, y] = n.node;

                node.transform.position = new Vector3(curx, cury, 0.0f);
                cury -= distanceBetween;
            }
            curx += distanceBetween;
            cury = 0 + (boardSize / 2 * distanceBetween);
        }
	}



    public void CheckBoard(NodeBehavior last)
    {
        if (boardManager.WonGame(last.node))
        {
            print(last.Color + " WON!");
            SceneManager.LoadScene("UIProto");
        }
        foreach (Node capture in boardManager.FindCaptures(last.node))
        {
            capture.color = eColor.EMPTY;
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
        boardManager.SaveNodesToFile(savePath);
    }

    public void Load()
    {
        string loadPath = EditorUtility.OpenFilePanel("Load Game", "", "pente");
        boardManager.LoadNodesFromFile(loadPath);
    }

}
