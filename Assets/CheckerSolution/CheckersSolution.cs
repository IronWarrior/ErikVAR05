using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class CheckersSolution : MonoBehaviour
{
    public MovementConstraints constraint;

    public PieceSolution piecePrefab;

    public CheckersBoard board;

    private List<PieceSolution> pieces = new List<PieceSolution>();

    public enum MovementConstraints { Free, Checkers }

    private void Start()
    {
        AddPiece(1, 1);
        AddPiece(4, 4);
    }

    private void AddPiece(int x, int y)
    {
        // Check if there is a piece already here, and if so, DO NOT allow
        // the placement.
        if (TryGetPieceAtLocation(x, y, out _))
        {
            throw new System.Exception
                ($"Attempting to add piece at {x}, {y} when there already is a piece located there.");
        }
        // Throwing an exception is like "return", in that it exists the current context.

        PieceSolution piece = Instantiate(piecePrefab);
        piece.SetPosition(x, y);

        pieces.Add(piece);
    }

    private bool TryGetPieceAtLocation(int x, int y, out PieceSolution piece)
    {
        foreach (PieceSolution candidate in pieces)
        {
            if (candidate.x == x && candidate.y == y)
            {
                piece = candidate;
                return true;
            }
        }

        piece = null;
        return false;
    }

    private bool TryMovePiece(PieceSolution piece, int targetX, int targetY)
    {
        // Constrain the movement to the board.
        if (targetX > board.xSize - 1 || targetX < 0 || targetY > board.ySize - 1 || targetY < 0)
        {
            return false;
        }

        int offsetX = piece.x - targetX;
        int offsetY = piece.y - targetY;

        // "Absolute value" means the number turns positive, regardless of
        // whether it was negative or positive before.
        // e.g., Abs(-5) = 5, Abs(2) = 2
        int distanceX = (int)Mathf.Abs(offsetX);
        int distanceY = (int)Mathf.Abs(offsetY);

        // Constrain movement by rules.
        if (constraint == MovementConstraints.Checkers)
        {
            bool isDiagonal = distanceX == 1 && distanceY == 1;

            if (isDiagonal == false)
            {
                return false;
            }
        }

        if (TryGetPieceAtLocation(targetX, targetY, out _) == false)
        {
            // Check if this was a "jump" move, in that it was longer than 1 tile.
            bool isJumpMove = (int)Mathf.Abs(targetX - piece.x) > 1;

            if (isJumpMove)
            {
                int directionX = targetX - piece.x > 0 ? 1 : -1;
                int directionY = targetY - piece.y > 0 ? 1 : -1;

                if (TryGetPieceAtLocation
                    (piece.x + directionX, piece.y + directionY, out PieceSolution capturedPiece))
                {
                    Debug.Log($"Captured piece at {capturedPiece.x}, {capturedPiece.y}");
                }

            }

            piece.SetPosition(targetX, targetY);

            return true;
        }

        return false;
    }

    #region Selecting Pieces
    private PieceSolution selectedPiece = null;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Raycasting!
            // Ray ray = new Ray(transform.position, transform.forward);
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            bool didWeHitAnything = Physics.Raycast(ray, out RaycastHit hit);

            if (didWeHitAnything == true)
            {
                // Are we placing a piece?
                if (selectedPiece != null)
                {
                    // What tile did we hit on the board?             
                    int xHit = Mathf.RoundToInt(hit.point.x);
                    int yHit = Mathf.RoundToInt(hit.point.z);

                    if (TryMovePiece(selectedPiece, xHit, yHit))
                    {
                        selectedPiece = null;
                    }

                    Debug.Log($"We hit point: {hit.point} resulting in {xHit}, {yHit}");
                }
                // ...or are we selecting a piece?
                else
                {
                    selectedPiece = hit.collider.gameObject.GetComponent<PieceSolution>();

                    if (selectedPiece != null)
                    {
                        Debug.Log($"selected piece at {selectedPiece.x}, {selectedPiece.y}");
                    }
                }

                Debug.DrawRay(hit.point, Vector3.up, Color.cyan, 2);
            }

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow, 2);
        }
    }
    #endregion
}
