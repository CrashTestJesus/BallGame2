using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour {
    // ooo
    // oxo
    // ooo
    public GameObject[,] neighbors = new GameObject[3,3];

    public int x, y;

    public float height;

    public CreateMap map;

    public bool initialised = false;

    public void grow(float step)
    {
        transform.localScale += new Vector3(0, step, 0);
    }

    public void init()
    {
        map = FindObjectOfType<CreateMap>();
        

        if (x > 0 && y > 0 && x < map.sizeX -1 && y < map.sizeY-1)
        {
            //1e rij 
            
            neighbors[0, 0] = map.level[x - 1, y - 1];
            neighbors[1, 0] = map.level[x - 0, y - 1];
            neighbors[2, 0] = map.level[x + 1, y - 1];
            
            //2e rij
            neighbors[0, 1] = map.level[x - 1, y];
            //zelf moet null zijn
            neighbors[2, 1] = map.level[x + 1, y];

            //3e rij
            neighbors[0, 2] = map.level[x - 1, y + 1];
            neighbors[1, 2] = map.level[x - 0, y + 1];
            neighbors[2, 2] = map.level[x + 1, y + 1];
        }
        initialised = true;
    }

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
   public SaveClass Save()
    {
        height = transform.localScale.y;
        SaveClass save = new SaveClass( x,y,gameObject.transform, height);
        Debug.Log(neighbors.Length);
        return save;
    }
}
[SerializeField]
public class SaveClass
{
    public int x, y;
    public Transform trans;
    public float height;

    public SaveClass( int xpos, int ypos, Transform t, float h)
    {
        x = xpos;
        y = ypos;
        trans = t;
        height = h;
    }
}
