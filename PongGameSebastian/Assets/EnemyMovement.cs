using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform Pong;

	public float Speed = 4.0f;
	float _activefollowRadius = 6.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		var step = Speed * Time.deltaTime;

		if (IsPlayerWithinFollowRadius())
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, Pong.transform.position.y, this.transform.position.z), step);
		}

	}
	bool IsPlayerWithinFollowRadius()
	{
		var distanceToPlayer = (Pong.transform.position - this.transform.position).magnitude;
		if (distanceToPlayer <= _activefollowRadius)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


}