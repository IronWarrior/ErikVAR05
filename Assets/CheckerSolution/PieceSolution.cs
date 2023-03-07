using UnityEngine;

public class PieceSolution : MonoBehaviour
{
    public int x, y;

    public void SetPosition(int newX, int newY)
    {
        x = newX;
        y = newY;

        transform.position = new Vector3(x, 0, y);
    }
}
