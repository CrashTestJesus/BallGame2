using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {

    public Transform ball;

    public float speed;
	
	void Update () {
        transform.position = Vector3.Lerp(transform.position, ball.position + new Vector3(0, 5, -2), speed * Time.deltaTime); 
	}
}
