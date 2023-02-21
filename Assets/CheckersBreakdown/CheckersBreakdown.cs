using UnityEngine;
using UnityEngine.InputSystem;

public class CheckersBreakdown : MonoBehaviour
{
    public PieceBehaviour piecePrefab;

    // A board is an NxN (8x8 for checkers) (when I write "N", I usually mean "number",
    // as in some arbitrary amount) collection of tiles.
    // On this board, each tile MAY contain a single piece.

    // A 2D array is a suggestion.
    // A 1D array would look like this [2] [4] [1] [0] [0]
    // A 2D could be
    // [ ] [ ] [ ]
    // [ ] [ ] [ ]
    // [ ] [ ] [ ]
    
    // A list of pieces?
    // List<Piece?>

    class Piece
    {
        public int x, y;
    }

    private void Awake()
    {
        //Piece piece = new Piece() { x = 2, y = 3 };

        //// "spawn" = "create"
        //var spawnedPiece = Instantiate(piecePrefab);
        //spawnedPiece.transform.position = new Vector3(piece.x, 0, piece.y);

        PieceBehaviour piece = Instantiate(piecePrefab);
        piece.SetPosition(2, 3);

        PieceBehaviour otherPiece = Instantiate(piecePrefab);
        otherPiece.SetPosition(-4, 3);
    }

    private PieceBehaviour selectedPiece = null;

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

                    Debug.Log($"We hit point: {hit.point} resulting in {xHit}, {yHit}");

                    selectedPiece.SetPosition(xHit, yHit);

                    selectedPiece = null;
                }
                // ...or are we selecting a piece?
                else
                {
                    selectedPiece = hit.collider.gameObject.GetComponent<PieceBehaviour>();

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
}
