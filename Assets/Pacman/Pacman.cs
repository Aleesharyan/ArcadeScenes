using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pacman : MonoBehaviour
{
	//how fast the player can move
	public float mySpeed;
	
	//tracking number of lives here
	int lives = 3;
	
	//number of pips uneaten- we check this in Start()!
	int pipsRemaining;
	
	//This is unity's pathfinding gadget
	//so long as we tell this agent where to go, it'll handle the motion for us!
	NavMeshAgent agent;
	
	
    // Start is called before the first frame update
    void Start()
    {
		//this returns an array- we store it's size and then toss it out!
		//an easy way to count all the pips at the start of the game.
		pipsRemaining = GameObject.FindObjectsOfType<Pip>().Length;
		
		//hook up the reference
		//set agent speed
        agent = this.GetComponent<NavMeshAgent>();
		agent.speed = mySpeed;
		
		//yellow for pacman!
		this.GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		//get player input
		Vector3 targetMove = new Vector3(Input.GetAxisRaw("Horizontal")*0.5f,0,Input.GetAxisRaw("Vertical")*0.5f);
		//tell the nav agent where we want to travel to!
		agent.destination = this.transform.position + targetMove;
		
    }
	
	void OnCollisionEnter(Collision collisionData)
	{
		if(collisionData.gameObject.GetComponent<Ghost>()!=null)
		{
			//I collided with a ghost!
			lives--;
			//run an event! Lots of objects need resetting, UI updating etc.
			//probably better check for gameover here too?
		}
		
		if(collisionData.gameObject.GetComponent<Pip>()!=null)
		{
			//I collided with a pip!
			//run an event! Lots of objects need resetting, UI updating etc.
			//probably want to update that pipsRemaining value etc. too.
			
		}
		
		
	}
	
	
	
	void Death()
	{
		//Lots of things to do here! Are we deleting pacman or just reseting his position?
		//this will probably be subscribed to a specific Event!
	}
	
	
	
	
}