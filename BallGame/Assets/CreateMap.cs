using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour {

    public int sizeX, sizeY;
    public float step;

    public GameObject pole;

    public bool done = false;

    public List<GameObject> level = new List<GameObject>();

    void Start()
    {
        Create();
    }

    void Update()
    {
        if (level.Count == (sizeX * sizeX))
        {
            done = true;
        }
    }

    void Create()
    {
        float xpos = 0, ypos = 0;
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                GameObject temp = Instantiate(pole, new Vector3(xpos, 0, ypos), Quaternion.identity);
                temp.transform.parent = this.gameObject.transform;
                Pole poleScript = temp.GetComponent<Pole>();
                poleScript.x = x;
                poleScript.y = y;
                level.Add(temp);
                xpos += step;
            }
            xpos = 0;
            ypos += step;
        }
    }
}
