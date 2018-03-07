using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour {
    // ooo
    // oxo
    // ooo
    GameObject[,] neighbors = new GameObject[3,3];

    public int x, y;

    public int height;

    public GameObject[] getDirectNeighbors()
    {
        List<GameObject> temp = new List<GameObject>();
        
        if(neighbors[1,0] != null)
        {
            temp.Add(neighbors[1, 0]);
        }
        if (neighbors[2, 1] != null)
        {
            temp.Add(neighbors[2, 1]);
        }
        if (neighbors[1, 2] != null)
        {
            temp.Add(neighbors[1, 2]);
        }
        if (neighbors[0, 1] != null)
        {
            temp.Add(neighbors[0, 1]);
        }
        return temp.ToArray();
    }

    public GameObject[] getAllNeighbors()
    {
        List<GameObject> temp = new List<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (neighbors[i, j] != null)
                {
                    temp.Add(neighbors[i, j]);
                }
            }
        }
        return temp.ToArray();
    }
}
