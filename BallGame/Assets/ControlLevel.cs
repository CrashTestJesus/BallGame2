using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLevel : MonoBehaviour {

    public int maxLength = 2;

    public float step = 0.05f;

    void Update()
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
        if (hit.collider.gameObject.CompareTag("Pole"))
        {
            GameObject temp = hit.collider.gameObject;
            if (temp.transform.localScale.y < maxLength)
            {
                temp.transform.localScale += new Vector3(0, step, 0);
            }
        }
    }
}
