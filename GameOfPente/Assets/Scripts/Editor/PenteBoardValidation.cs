using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class PenteBoardValidation {

    // Test neighbors, intersections that have 2, 3, and 4 neighbors
    [Test]
    public void TestIntersectionNeighbors()
    {
        
    }

    // Test captures, single, multiple, both players, false capture where player boxes themselves in
    // List<List<NodeBehavior>>
    [Test]
    public void TestSingleCaptureVariations()
    {
        // Vertical, horizontal, diagonal
        BoardManagerBehavior bm = new BoardManagerBehavior();
        bm.Initialize(19);
        bm.NodeBehaviors[0, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;
        NodeBehavior node1 = bm.NodeBehaviors[0, 1].GetComponent<NodeBehavior>();
        node1.Color = eColor.WHITE;

        NodeBehavior node2 = bm.NodeBehaviors[0, 2].GetComponent<NodeBehavior>();
        node2.Color = eColor.WHITE;

        bm.NodeBehaviors[0, 3].GetComponent<NodeBehavior>().Color = eColor.BLACK;

        List<NodeBehavior> nodes = bm.FindCaptures(bm.NodeBehaviors[0, 3].GetComponent<NodeBehavior>());


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        bm.CheckBoard(bm.NodeBehaviors[0, 3].GetComponent<NodeBehavior>());
        Assert.IsTrue(bm.NodeBehaviors[0, 1].GetComponent<NodeBehavior>().Color == eColor.EMPTY);
        Assert.IsTrue(bm.NodeBehaviors[0, 2].GetComponent<NodeBehavior>().Color == eColor.EMPTY);



        bm = new BoardManagerBehavior();
        bm.Initialize(19);
        bm.NodeBehaviors[0, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;
        node1 = bm.NodeBehaviors[1, 1].GetComponent<NodeBehavior>();
        node1.Color = eColor.WHITE;

        node2 = bm.NodeBehaviors[2, 2].GetComponent<NodeBehavior>();
        node2.Color = eColor.WHITE;

        bm.NodeBehaviors[3, 3].GetComponent<NodeBehavior>().Color = eColor.BLACK;

        nodes = bm.FindCaptures(bm.NodeBehaviors[3, 3].GetComponent<NodeBehavior>());


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        bm.CheckBoard(bm.NodeBehaviors[3, 3].GetComponent<NodeBehavior>());
        Assert.IsTrue(bm.NodeBehaviors[1, 1].GetComponent<NodeBehavior>().Color == eColor.EMPTY);
        Assert.IsTrue(bm.NodeBehaviors[2, 2].GetComponent<NodeBehavior>().Color == eColor.EMPTY);

        bm = new BoardManagerBehavior();
        bm.Initialize(19);
        bm.NodeBehaviors[0, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;
        node1 = bm.NodeBehaviors[1, 0].GetComponent<NodeBehavior>();
        node1.Color = eColor.WHITE;

        node2 = bm.NodeBehaviors[2, 0].GetComponent<NodeBehavior>();
        node2.Color = eColor.WHITE;

        bm.NodeBehaviors[3, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;

        nodes = bm.FindCaptures(bm.NodeBehaviors[3, 0].GetComponent<NodeBehavior>());


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        bm.CheckBoard(bm.NodeBehaviors[3, 0].GetComponent<NodeBehavior>());
        Assert.IsTrue(bm.NodeBehaviors[1, 0].GetComponent<NodeBehavior>().Color == eColor.EMPTY);
        Assert.IsTrue(bm.NodeBehaviors[2, 0].GetComponent<NodeBehavior>().Color == eColor.EMPTY);
    }

    [Test]
    public void TestMultipleCapture()
    {

    }

    [Test]
    public void TestFalseCapture()
    {
        BoardManagerBehavior bm = new BoardManagerBehavior();
        bm.Initialize(19);
        bm.NodeBehaviors[0, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;
        NodeBehavior node1 = bm.NodeBehaviors[0, 1].GetComponent<NodeBehavior>();
        node1.Color = eColor.WHITE;

        NodeBehavior node2 = bm.NodeBehaviors[0, 2].GetComponent<NodeBehavior>();
        node2.Color = eColor.WHITE;

        bm.NodeBehaviors[0, 3].GetComponent<NodeBehavior>().Color = eColor.BLACK;

        bm.CheckBoard(bm.NodeBehaviors[0, 2].GetComponent<NodeBehavior>());
        Assert.IsTrue(bm.NodeBehaviors[0, 1].GetComponent<NodeBehavior>().Color == eColor.WHITE);
        Assert.IsTrue(bm.NodeBehaviors[0, 2].GetComponent<NodeBehavior>().Color == eColor.WHITE);



        bm = new BoardManagerBehavior();
        bm.Initialize(19);
        bm.NodeBehaviors[0, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;
        node1 = bm.NodeBehaviors[1, 1].GetComponent<NodeBehavior>();
        node1.Color = eColor.WHITE;

        node2 = bm.NodeBehaviors[2, 2].GetComponent<NodeBehavior>();
        node2.Color = eColor.WHITE;

        bm.NodeBehaviors[3, 3].GetComponent<NodeBehavior>().Color = eColor.BLACK;

        bm.CheckBoard(bm.NodeBehaviors[2, 2].GetComponent<NodeBehavior>());
        Assert.IsTrue(bm.NodeBehaviors[1, 1].GetComponent<NodeBehavior>().Color == eColor.WHITE);
        Assert.IsTrue(bm.NodeBehaviors[2, 2].GetComponent<NodeBehavior>().Color == eColor.WHITE);

        bm = new BoardManagerBehavior();
        bm.Initialize(19);
        bm.NodeBehaviors[0, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;
        node1 = bm.NodeBehaviors[1, 0].GetComponent<NodeBehavior>();
        node1.Color = eColor.WHITE;

        node2 = bm.NodeBehaviors[2, 0].GetComponent<NodeBehavior>();
        node2.Color = eColor.WHITE;

        bm.NodeBehaviors[3, 0].GetComponent<NodeBehavior>().Color = eColor.BLACK;

        bm.CheckBoard(bm.NodeBehaviors[2, 0].GetComponent<NodeBehavior>());
        Assert.IsTrue(bm.NodeBehaviors[1, 0].GetComponent<NodeBehavior>().Color == eColor.WHITE);
        Assert.IsTrue(bm.NodeBehaviors[2, 0].GetComponent<NodeBehavior>().Color == eColor.WHITE);
    }

    // Test tria finder
    [Test]
    public void TestTriaFinder()
    {

    }

    [Test]
    public void TestBlockedTriaFinder()
    {

    }

    [Test]
    public void TestGapTriaFinder()
    {

    }

    // Test tessera finder
    [Test]
    public void TestTesseraFinder()
    {

    }

    [Test]
    public void TestBlockedTesseraFinder()
    {

    }

    // Test win condition, capture more than 5
    [Test]
    public void TestFiveInRowVariations()
    {

    }

    [Test]
    public void TestCaptureWin()
    {

    }

    [Test]
    public void TestOverkillWin()
    {



    }

    // Test placement, black first move and tournament rule, piece on top of piece
    [Test]
    public void TestBlackFirstMove()
    {
        GameObject go = new GameObject();
        BoardManagerBehavior bm = go.AddComponent<BoardManagerBehavior>();
        bm.NodeBehaviorTemplate = GameObject.Instantiate(Resources.Load("Prefabs/NodeBehavior")) as GameObject;
        bm.Initialize(19);
        int center = 19 / 2;
        NodeBehavior n = bm.GetNodeBehavior(center, center);

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNodeBehavior(center, center), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNodeBehavior(1, 1), eColor.BLACK));


    }

    [Test]
    public void TestBlackSecondMove()
    {
        BoardManagerBehavior bm = new BoardManagerBehavior();
        bm.Initialize(19);
        int center = 19 / 2;

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNodeBehavior(center +1, center-1), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNodeBehavior(0, 0), eColor.BLACK));
    }

    [Test]
    public void TestPiecePlacedOnPiece()
    {
        BoardManagerBehavior bm = new BoardManagerBehavior();
        bm.Initialize(19);
        int center = 19 / 2;

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNodeBehavior(center, center), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 1, bm.GetNodeBehavior(center, center), eColor.WHITE));
    }

    [Test]
    public void TestBlackMovesFirst()
    {
        BoardManagerBehavior bm = new BoardManagerBehavior();
        bm.Initialize(19);


        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 0, bm.GetNodeBehavior(0, 0), eColor.WHITE));
    }


}