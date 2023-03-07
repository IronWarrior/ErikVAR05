using UnityEngine;

public class CheckersBoard : MonoBehaviour
{
    public GameObject tilePrefab;

    public int xSize = 8, ySize = 8;

    private void Awake()
    {
        // Spawn a bunch of visuals to make up the board.
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
    }
}
