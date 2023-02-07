using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaceBreakdown : MonoBehaviour
{
    // Data driven programming!
    public float turnDuration = 1;

    // Different ways to represent the "ground truth" of the application.
    // or the "data structure" that represents the course.
    public List<string> benCourse = new List<string>()
    {
        "Grass",
        "Grass",
        "Mud",
        "Grass",
    };

    public List<GameObject> courseFromUnity = new List<GameObject>();

    //public class TileDataStructure
    //{
    //    // In programming, perents are usually 0.0-1.0f.
    //    public float percentChanceToMove = 0.25f;
    //}

    public List<Tile> tileCourse;

    public class Student
    {
        public string firstName = "Erik";
        public string lastName = "Ross";
        public int id;
        public int age;
    }

    private int runnerA = 0;

    private void Start()
    {
        Debug.Log("Printing Ben's tiles.");

        foreach (string tile in benCourse)
        {
            // Created some game objects for the "view" or "visuals"
            bool isGrass = tile == "Grass";

            Debug.Log($"This tile is grass: {isGrass}");

            //if (isGrass == true)
            //{
            //    float chanceToMoveForward = 0.25f;
            //}
        }

        Debug.Log("Printing the course made in Unity.");

        foreach (GameObject tile in courseFromUnity)
        {
            // Created some game objects for the "view" or "visuals"
            bool isGrass = tile.name == "Grass";

            Debug.Log($"This tile is grass: {isGrass}");

            //if (isGrass == true)
            //{
            //    float chanceToMoveForward = 0.25f;
            //}
        }

        Debug.Log("Printing the tile course.");

        foreach (Tile tile in tileCourse)
        {
            Debug.Log($"This tile has a {tile.ChanceToMove}% chance to move forward.");
        }

        //StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        int currentTurn = 0;

        while (true)
        {
            GameUpdate();

            Debug.Log($"Turn #{currentTurn}");

            yield return new WaitForSeconds(turnDuration);

            currentTurn++;
        }
    }

    private void GameUpdate()
    {
        // Attempt to move every runner, since depending on the terrain
        // and their luck they may or may not move.
    }
}
