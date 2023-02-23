using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CheckersUIBreakdown : MonoBehaviour
{
    private Button[] buttons;

    class Piece
    {
        public int x, y;
    }

    private List<Piece> pieces = new List<Piece>();

    private void Awake()
    {
        pieces.Add(new Piece() { x=1, y=1 });
        pieces.Add(new Piece() { x = 2, y = 2 });

        buttons = GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];

            To2D(i, out int x, out int y);

            button.onClick.AddListener(() => OnTileClicked(x, y));
        }

        UpdateBoard();
    }

    private void To2D(int i, out int x, out int y)
    {
        // Convert the 1 dimensional index into a two dimensional one.
        x = i % 4;
        y = i / 4;
    }

    private int To1D(int x, int y)
    {
        return y * 4 + x;
    }

    private void OnTileClicked(int x, int y)
    {
        Debug.Log($"Tile clicked: {x}, {y}");

        buttons[To1D(x, y)].GetComponentInChildren<Image>().color = Color.red;
    }

    private void UpdateBoard()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            To2D(i, out int x, out int y);

            bool containsPiece = false;

            foreach (Piece piece in pieces)
            {
                if (piece.x == x && piece.y == y)
                {
                    containsPiece = true;
                }
            }

            if (containsPiece == true)
                buttons[i].GetComponentInChildren<Image>().color = Color.blue;
            else
                buttons[i].GetComponentInChildren<Image>().color = Color.white;
        }
    }
}
