using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFix : MonoBehaviour {


    Rigidbody rig;
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	
	void Update () {
		if(rig.velocity == Vector3.zero)
        {
            rig.velocity = new Vector3(0, 0.1f, 0);
        }
	}
}
