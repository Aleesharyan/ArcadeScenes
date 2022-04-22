using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
	
	
	
	public float speed;
	//how often can we move?
	public float moveTimer = 0.2f;
	float currentMoveTimer =0;
	
	//map edges
	float boundsRight = 25;
	
	
	
	void Update()
	{
		
		currentMoveTimer+=Time.deltaTime;
		if(Input.GetAxisRaw("Horizontal")!=0&&currentMoveTimer>moveTimer)
		{
			this.transform.position+=new Vector3((Input.GetAxisRaw("Horizontal")*speed),0,0);
			currentMoveTimer = 0;
		}
		
		//clamp to game space
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,-boundsRight,boundsRight),this.transform.position.y,this.transform.position.z);
		
		
    }
	
	
	
	void OnCollisionEnter(Collision collisionData)
	{
		//did we collide with a bullet?
		if(collisionData.gameObject.GetComponent<Bullet>()!=null)
		{
			//an alien bullet?
			if(collisionData.gameObject.GetComponent<Bullet>().ownershipPlayer==false)
			{
				//Looks like a job for an event!
				//freeze player movement?
				//reduce lives by 1?
			}
		}
		
		//did we collide with an invader?
		if(collisionData.gameObject.GetComponent<SpaceInvader>()!=null)
		{
			//again, probably a good opportunity for an event!
		}
		
	}
	
	
}
