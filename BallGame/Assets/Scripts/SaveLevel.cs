using System.IO;
using System.Collections.Generic;
using UnityEngine;



public class SaveLevel : MonoBehaviour {

    public CreateMap map;

    public GameObject polePref;
    public GameObject emptyPref;
    public GameObject terrain;

    SaveClass[] level;

    int mapsizeX, mapsizeY;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetLevel();
        }
    }

    void GetLevel()
    {
        mapsizeX = map.sizeX;
        mapsizeY = map.sizeY;
        List<GameObject> temp = new List<GameObject>();


        for (int y = 0; y < map.sizeY; y++)
        {
            for (int x = 0; x < map.sizeX; x++)
            {
                if (map.level[x, y] != null)
                {

                    temp.Add(map.level[x, y]);
                }
                else
                {
                    GameObject empty = Instantiate(emptyPref, Vector3.zero, Quaternion.identity);
                    Pole pole = empty.GetComponent<Pole>();
                    pole.x = x;
                    pole.y = y;
                    pole.height = 1;
                    map.level[x, y] = empty;
                    temp.Add(map.level[x, y]);
                }
            }
        }
        level = new SaveClass[temp.Count];
        for (int i = 0; i < temp.Count; i++)
        {
            level[i] = temp[i].GetComponent<Pole>().Save();
        }
        
        destroyOld();
    }
    void destroyOld()
    {
        for (int y = 0; y < map.sizeY; y++)
        {
            for (int x = 0; x < map.sizeX; x++)
            {
                if (map.level[x, y] != null)
                {
                    Destroy(map.level[x, y]);
                }
            }
        }
        recreateLevel();
    }

    void recreateLevel()
    {
        for (int i = 0; i < level.Length; i++)
        {
            GameObject temp = Instantiate(polePref, level[i].trans.position, Quaternion.identity);
            temp.transform.parent = terrain.transform;
            Pole poleScript = temp.GetComponent<Pole>();
            poleScript.x = level[i].x;
            poleScript.y = level[i].y;
            poleScript.height = level[i].height;
            temp.transform.localScale = new Vector3(temp.transform.localScale.x, level[i].height, temp.transform.localScale.z);
            map.level[level[i].x, level[i].y] = temp;
        }
        map.initDelayCaller();
    }
}
[System.Serializable]
public class LevelClass
{
    public SaveClass[] level;
}
