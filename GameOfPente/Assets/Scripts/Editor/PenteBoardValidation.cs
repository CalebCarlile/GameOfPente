using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;


public class PenteBoardValidation {

    // Test neighbors, intersections that have 2, 3, and 4 neighbors
    [Test]
    public void TestIntersectionNeighbors()
    {
        
    }

    // Test captures, single, multiple, both players, false capture where player boxes themselves in
    // List<List<Node>>
    [Test]
    public void TestSingleCaptureVariations()
    {
        // Vertical, horizontal, diagonal
        BoardManager bm = new BoardManager();
        bm.Initialize(19);
        bm.Nodes[0, 0].GetComponent<Node>().Color = eColor.BLACK;
        Node node1 = bm.Nodes[0, 1].GetComponent<Node>();
        node1.Color = eColor.WHITE;

        Node node2 = bm.Nodes[0, 2].GetComponent<Node>();
        node2.Color = eColor.WHITE;

        bm.Nodes[0, 3].GetComponent<Node>().Color = eColor.BLACK;

        List<Node> nodes = bm.FindCaptures(bm.Nodes[0, 3].GetComponent<Node>());


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        bm.CheckBoard(bm.Nodes[0, 3].GetComponent<Node>());
        Assert.IsTrue(bm.Nodes[0, 1].GetComponent<Node>().Color == eColor.EMPTY);
        Assert.IsTrue(bm.Nodes[0, 2].GetComponent<Node>().Color == eColor.EMPTY);



        bm = new BoardManager();
        bm.Initialize(19);
        bm.Nodes[0, 0].GetComponent<Node>().Color = eColor.BLACK;
        node1 = bm.Nodes[1, 1].GetComponent<Node>();
        node1.Color = eColor.WHITE;

        node2 = bm.Nodes[2, 2].GetComponent<Node>();
        node2.Color = eColor.WHITE;

        bm.Nodes[3, 3].GetComponent<Node>().Color = eColor.BLACK;

        nodes = bm.FindCaptures(bm.Nodes[3, 3].GetComponent<Node>());


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        bm.CheckBoard(bm.Nodes[3, 3].GetComponent<Node>());
        Assert.IsTrue(bm.Nodes[1, 1].GetComponent<Node>().Color == eColor.EMPTY);
        Assert.IsTrue(bm.Nodes[2, 2].GetComponent<Node>().Color == eColor.EMPTY);

        bm = new BoardManager();
        bm.Initialize(19);
        bm.Nodes[0, 0].GetComponent<Node>().Color = eColor.BLACK;
        node1 = bm.Nodes[1, 0].GetComponent<Node>();
        node1.Color = eColor.WHITE;

        node2 = bm.Nodes[2, 0].GetComponent<Node>();
        node2.Color = eColor.WHITE;

        bm.Nodes[3, 0].GetComponent<Node>().Color = eColor.BLACK;

        nodes = bm.FindCaptures(bm.Nodes[3, 0].GetComponent<Node>());


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        bm.CheckBoard(bm.Nodes[3, 0].GetComponent<Node>());
        Assert.IsTrue(bm.Nodes[1, 0].GetComponent<Node>().Color == eColor.EMPTY);
        Assert.IsTrue(bm.Nodes[2, 0].GetComponent<Node>().Color == eColor.EMPTY);
    }

    [Test]
    public void TestMultipleCapture()
    {

    }

    [Test]
    public void TestFalseCapture()
<<<<<<< HEAD
    {
        
=======
    {
        BoardManager bm = new BoardManager();
        bm.Initialize(19);
        bm.Nodes[0, 0].GetComponent<Node>().Color = eColor.BLACK;
        Node node1 = bm.Nodes[0, 1].GetComponent<Node>();
        node1.Color = eColor.WHITE;

        Node node2 = bm.Nodes[0, 2].GetComponent<Node>();
        node2.Color = eColor.WHITE;

        bm.Nodes[0, 3].GetComponent<Node>().Color = eColor.BLACK;

        bm.CheckBoard(bm.Nodes[0, 2].GetComponent<Node>());
        Assert.IsTrue(bm.Nodes[0, 1].GetComponent<Node>().Color == eColor.WHITE);
        Assert.IsTrue(bm.Nodes[0, 2].GetComponent<Node>().Color == eColor.WHITE);



        bm = new BoardManager();
        bm.Initialize(19);
        bm.Nodes[0, 0].GetComponent<Node>().Color = eColor.BLACK;
        node1 = bm.Nodes[1, 1].GetComponent<Node>();
        node1.Color = eColor.WHITE;

        node2 = bm.Nodes[2, 2].GetComponent<Node>();
        node2.Color = eColor.WHITE;

        bm.Nodes[3, 3].GetComponent<Node>().Color = eColor.BLACK;

        bm.CheckBoard(bm.Nodes[2, 2].GetComponent<Node>());
        Assert.IsTrue(bm.Nodes[1, 1].GetComponent<Node>().Color == eColor.WHITE);
        Assert.IsTrue(bm.Nodes[2, 2].GetComponent<Node>().Color == eColor.WHITE);

        bm = new BoardManager();
        bm.Initialize(19);
        bm.Nodes[0, 0].GetComponent<Node>().Color = eColor.BLACK;
        node1 = bm.Nodes[1, 0].GetComponent<Node>();
        node1.Color = eColor.WHITE;

        node2 = bm.Nodes[2, 0].GetComponent<Node>();
        node2.Color = eColor.WHITE;

        bm.Nodes[3, 0].GetComponent<Node>().Color = eColor.BLACK;

        bm.CheckBoard(bm.Nodes[2, 0].GetComponent<Node>());
        Assert.IsTrue(bm.Nodes[1, 0].GetComponent<Node>().Color == eColor.WHITE);
        Assert.IsTrue(bm.Nodes[2, 0].GetComponent<Node>().Color == eColor.WHITE);
>>>>>>> origin/master
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
        BoardManager bm = new BoardManager();
        bm.Initialize(19);
        int center = 19 / 2;
        Node n = bm.GetNode(center, center);

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(center, center), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(1, 1), eColor.BLACK));


    }

    [Test]
    public void TestBlackSecondMove()
    {
        BoardManager bm = new BoardManager();
        bm.Initialize(19);
        int center = 19 / 2;

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNode(center +1, center-1), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNode(0, 0), eColor.BLACK));
    }

    [Test]
    public void TestPiecePlacedOnPiece()
    {
        BoardManager bm = new BoardManager();
        bm.Initialize(19);
        int center = 19 / 2;

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(center, center), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 1, bm.GetNode(center, center), eColor.WHITE));
    }

    [Test]
    public void TestBlackMovesFirst()
    {
        BoardManager bm = new BoardManager();
        bm.Initialize(19);


        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 0, bm.GetNode(0, 0), eColor.WHITE));
    }


}
