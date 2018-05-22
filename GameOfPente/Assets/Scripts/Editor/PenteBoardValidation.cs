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
    // List<List<Node>>
    [Test]
    public void TestSingleCaptureVariations()
    {
        // Vertical, horizontal, diagonal
        BoardManager bm = new BoardManager();
        bm.Init(19);
        bm.nodes[0, 0].color = eColor.BLACK;
        Node node1 = bm.nodes[0, 1];
        node1.color = eColor.WHITE;

        Node node2 = bm.nodes[0, 2];
        node2.color = eColor.WHITE;

        bm.nodes[0, 3].color = eColor.BLACK;

        List<Node> nodes = bm.FindCaptures(bm.nodes[0, 3]);


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        //bm.CheckBoard(bm.nodes[0, 3]);
        Assert.IsTrue(bm.nodes[0, 1].color == eColor.EMPTY);
        Assert.IsTrue(bm.nodes[0, 2].color == eColor.EMPTY);



        bm = new BoardManager();
        bm.Init(19);
        bm.nodes[0, 0].color = eColor.BLACK;
        node1 = bm.nodes[1, 1];
        node1.color = eColor.WHITE;

        node2 = bm.nodes[2, 2];
        node2.color = eColor.WHITE;

        bm.nodes[3, 3].color = eColor.BLACK;

        nodes = bm.FindCaptures(bm.nodes[3, 3]);


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        //bm.CheckBoard(bm.nodes[3, 3]);
        Assert.IsTrue(bm.nodes[1, 1].color == eColor.EMPTY);
        Assert.IsTrue(bm.nodes[2, 2].color == eColor.EMPTY);

        bm = new BoardManager();
        bm.Init(19);
        bm.nodes[0, 0].color = eColor.BLACK;
        node1 = bm.nodes[1, 0];
        node1.color = eColor.WHITE;

        node2 = bm.nodes[2, 0];
        node2.color = eColor.WHITE;

        bm.nodes[3, 0].color = eColor.BLACK;

        nodes = bm.FindCaptures(bm.nodes[3, 0]);


        Assert.AreSame(nodes[0], node2);
        Assert.AreSame(nodes[1], node1);
        //bm.CheckBoard(bm.nodes[3, 0]);
        Assert.IsTrue(bm.nodes[1, 0].color == eColor.EMPTY);
        Assert.IsTrue(bm.nodes[2, 0].color == eColor.EMPTY);
    }

    [Test]
    public void TestMultipleCapture()
    {

    }

    [Test]
    public void TestFalseCapture()
    {
        BoardManager bm = new BoardManager();
        bm.Init(19);
        bm.nodes[0, 0].color = eColor.BLACK;
        Node node1 = bm.nodes[0, 1];
        node1.color = eColor.WHITE;

        Node node2 = bm.nodes[0, 2];
        node2.color = eColor.WHITE;

        bm.nodes[0, 3].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[0, 2]);
        Assert.IsTrue(bm.nodes[0, 1].color == eColor.WHITE);
        Assert.IsTrue(bm.nodes[0, 2].color == eColor.WHITE);



        bm = new BoardManager();
        bm.Init(19);
        bm.nodes[0, 0].color = eColor.BLACK;
        node1 = bm.nodes[1, 1];
        node1.color = eColor.WHITE;

        node2 = bm.nodes[2, 2];
        node2.color = eColor.WHITE;

        bm.nodes[3, 3].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[2, 2]);
        Assert.IsTrue(bm.nodes[1, 1].color == eColor.WHITE);
        Assert.IsTrue(bm.nodes[2, 2].color == eColor.WHITE);

        bm = new BoardManager();
        bm.Init(19);
        bm.nodes[0, 0].color = eColor.BLACK;
        node1 = bm.nodes[1, 0];
        node1.color = eColor.WHITE;

        node2 = bm.nodes[2, 0];
        node2.color = eColor.WHITE;

        bm.nodes[3, 0].color = eColor.BLACK;

        //bm.CheckBoard(bm.nodes[2, 0]);
        Assert.IsTrue(bm.nodes[1, 0].color == eColor.WHITE);
        Assert.IsTrue(bm.nodes[2, 0].color == eColor.WHITE);
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
        bm.Init(19);
        int center = 19 / 2;
        Node n = bm.GetNode(center, center);

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(center, center), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(1, 1), eColor.BLACK));


    }

    [Test]
    public void TestBlackSecondMove()
    {
        BoardManager bm = new BoardManager();
        bm.Init(19);
        int center = 19 / 2;

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNode(center +1, center-1), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 2, bm.GetNode(0, 0), eColor.BLACK));
    }

    [Test]
    public void TestPiecePlacedOnPiece()
    {
        BoardManager bm = new BoardManager();
        bm.Init(19);
        int center = 19 / 2;

        Assert.IsTrue(bm.IsValidPlacement(PlayerTurn.BLACK_PLAYER1, 0, bm.GetNode(center, center), eColor.BLACK));

        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 1, bm.GetNode(center, center), eColor.WHITE));
    }

    [Test]
    public void TestBlackMovesFirst()
    {
        BoardManager bm = new BoardManager();
        bm.Init(19);


        Assert.IsFalse(bm.IsValidPlacement(PlayerTurn.WHITE_PLAYER2, 0, bm.GetNode(0, 0), eColor.WHITE));
    }


}