using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

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

    }

    [Test]
    public void TestMultipleCapture()
    {

    }

    [Test]
    public void TestFalseCapture()
    {

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
