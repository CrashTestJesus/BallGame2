using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {

    public Transform ball;

    public float speed;

    public int yDist = 7, zDist = -3;
	
	void Update () {
        transform.position = Vector3.Lerp(transform.position, ball.position + new Vector3(0, yDist, zDist), speed * Time.deltaTime); 
	}
}
