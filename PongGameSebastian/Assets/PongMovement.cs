using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PongMovement : MonoBehaviour {
	public Transform EndPoint;
	public Transform EndPoint2;
	public Transform Deflectpoint;
	public Transform Deflectpoint2;
	public Transform MidPoint;

	public float Speed;
	public float invert = -1f;

	public float Yspeed = .09f;
	public float Xspeed = .09f;	
	float tempX;
	float tempY;

	private Rigidbody2D rb;

	public bool differentRange = false;
	public bool IsPongOutOfRange;
	public bool isGoingRight = true;
    public AudioClip pong_sound;
    private AudioSource source;

    Vector3 Position;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		Position = this.transform.position;

        source = GetComponent<AudioSource>();
    }



	// Update is called once per frame
	void Update()
    {
		Position.y += Yspeed;
		Position.x += Xspeed;

		this.transform.position = Position;
		if (this.transform.position.y >= Deflectpoint.transform.position.y || this.transform.position.y <= Deflectpoint2.transform.position.y) 
		{
			Yspeed = -Yspeed;
            source.PlayOneShot(pong_sound, 1.0f);
        }


		// if position is greater than the right point it will go back to the orgin
		if (Position.x >= EndPoint.transform.position.x) 
		{
			Position  = new Vector3 (0, 0, 0);
			//this.transform.position = new Vector3 (-5.0f, -6.0f, 0);
			this.transform.position = Position;
		} 
		else 
		{
			// if position is greater than the left point it will go back to the orgin
			if (Position.x <= EndPoint2.transform.position.x) 
			{
				Position = new Vector3 (0, 0, 0);
				//this.transform.position = new Vector3 (5.0f, 6.0f, 0);
				this.transform.position = Position;
			}
		}
	}

	void OnTriggerEnter2D()
	{
		Xspeed = -Xspeed;
        source.PlayOneShot(pong_sound, 1.0f);
    }
}
