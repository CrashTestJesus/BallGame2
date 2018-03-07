using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLevel : MonoBehaviour {

    public int maxLength = 2;

    public float step = 0.05f;
    public float falloff = 2;


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            shootRay();
        }
    }

    void shootRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Pole"))
            {
                GameObject temp = hit.collider.gameObject;
                if (temp.transform.localScale.y < maxLength)
                {
                    Pole pole = temp.GetComponent<Pole>();
                    pole.grow(step);
                    GameObject[] tempArr = pole.getAllNeighbors();
                    for (int i = 0; i < pole.getAllNeighbors().Length; i++)
                    {
                        if (tempArr[i].transform.localScale.y < maxLength)
                        {
                            tempArr[i].GetComponent<Pole>().grow(step / falloff);
                        }
                    }
                }
            }
        }
    }
}
