using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvader : MonoBehaviour
{
	//the object we'll use for a bullet later.
	public GameObject bulletPrefab;
	
	//map edges
	float boundsRight = 25;
	float boundsLeft = -25;
	
	//this controls how often the invaders will move
	//as the game goes on, they'll get faster and faster!
	public float moveTimer = 1;
	float currentTimer =0;
	
	//are we travelling right or left?
	bool movingRight = true;
	
	//how far we 'pop' on each movement.
	public float jumpVal = 3;
	
	//5% chance on every move (for any alien) to fire a bullet
	float chanceToFire = 0.05f;
	
    // Update is called once per frame
    void Update()
    {
		//update our move timer
        currentTimer+=Time.deltaTime;
		//if the move timer has been running long enough we can move!
		if(currentTimer>moveTimer)
		{
		
			if(movingRight)
			{
					//travel right
				this.transform.position+=Vector3.right*jumpVal;
			}
			else
			{
				//travel left
				this.transform.position-=Vector3.right*jumpVal;
			}
			
			//reset timer
			currentTimer=0;
			
			//decide whether to shoot at random
			if(Random.Range(0,1f)<chanceToFire)
			{
				FireBullet();
			}
		}
		
		//if we hit the left bounds while travelling left or right bounds while travelling right-
		//it's time to swap direction and move down.
		if((this.transform.position.x>boundsRight&&movingRight)||(this.transform.position.x<boundsLeft&&!movingRight))
		{
			//we can't just call for ChangeDirection();
			//that would ONLY affect this object.
			//something goes here to call an event
			//to have ALL the space invaders drop and change direction at once
			ChangeDirection();
		}
		
    }
	
	//makes the space invader drop and change direction!
	//probably subscribe this to an event of some kind!
	void ChangeDirection()
	{
		this.transform.position-=Vector3.up*jumpVal*2;
		movingRight=!movingRight;
		//increase the move speed slightly.
		moveTimer = Mathf.Lerp(moveTimer,0,0.3f);
		
	}
	
	//create a bullet that moves downwards on it's own and is not 'owned by the player' - it can hurt them!
	void FireBullet()
	{
		Bullet myBullet = Instantiate(bulletPrefab,this.transform.position,this.transform.rotation).GetComponent<Bullet>();;
		myBullet.ownershipPlayer = false;
		myBullet.speed *= 0.5f;
		
	}
	
	//collision tests!
	void OnCollisionEnter(Collision collisionData)
	{
		//did we collide with a bullet?
		if(collisionData.gameObject.GetComponent<Bullet>()!=null)
		{
			//a player-shot bullet?
			if(collisionData.gameObject.GetComponent<Bullet>().ownershipPlayer==true)
			{
				//call an event for UI/particle/score etc.
				//then destroy!
				//First destroy bullet
				Destroy(collisionData.gameObject);
				//then destroy this space invader
				Destroy(this.gameObject);
			}
		}
		
	}
	
	
	
}
