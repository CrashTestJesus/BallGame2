using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour {

    public int sizeX, sizeY;
    public float step;

    public GameObject pole;


    public GameObject[,] level;

    void Start()
    {
        level = new GameObject[sizeX,sizeY];
        Create();
    }

    void Update()
    {

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
                level[x, y] = temp;
                xpos += step;
            }
            xpos = 0;
            ypos += step;
        }

        initDelayCaller();
    }
    public void initDelayCaller()
    {
        StartCoroutine(initDelay());
    }

    IEnumerator initDelay()
    {
        while (level[sizeX-1, sizeY-1].GetComponent<Pole>().initialised == false)
        {
            yield return null;
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    level[j, i].GetComponent<Pole>().init();
                }
            }
        }
        Debug.Log("loaded");
    }
}
