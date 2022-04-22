
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	//how fast the player can move
	//we can set this in the editor
	public float mySpeed;
	
	//This is unity's pathfinding gadget
	//so long as we tell this agent where to go, it'll handle the motion for us!
	UnityEngine.AI.NavMeshAgent agent;
	
	//how many seconds between deciding where to move.
	public float recheckAI = 2;
	float recheckTimer = 0;
	
	//our target, the player character!
	GameObject thePlayer;
	
	//an enum to control ghost behaviour
	public enum GhostType
	{
		Hunter,
		Drifter,
		Ambush
	}
	
	//a specific variable enum to store THIS object's behaviour.
	public GhostType myType;
	
	
   // Start is called before the first frame update
    void Start()
    {
		//hook up the references
		//make sure the agent knows how fast we should be moving
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.speed = mySpeed;
		
		//we're not REALLY supposed to use GameObject.Find, but once at the start of the game isn't a big sin.
		thePlayer = GameObject.FindObjectOfType<Pacman>().gameObject;
		
		//colour the ghost based on their behaviour type!
		switch(myType)
		{
			case GhostType.Hunter:
				
				this.GetComponent<Renderer>().material.color = Color.red;
				
			break;
			
			//The drifter just moves entirely at random.
			case GhostType.Drifter:
				
				this.GetComponent<Renderer>().material.color = Color.blue;
				
			break;
			
			//The ambusher moves entirely at random- until the player is nearby, then it rushes you!
			case GhostType.Ambush:
			
				this.GetComponent<Renderer>().material.color = Color.green;
				
			break;
			
		}
		
		
    }

    // Update is called once per frame
    void Update()
    {
		//update the timer
		recheckTimer+=Time.deltaTime;
		
		//we don't want to be assigning AI commands CONSTANTLY- usually it's a bit of a waste of time
		//it can get performance hungry fast if we're rechecking our pathfinding over and over
		//and as a side benefit- the ghosts actually look MORE naturally intelligent if they go places, have a think
		//and *then* choose a new path!
		
		//if the AI recheck timer runs out       OR  we reach our last decided-upon destination.
		if(recheckTimer>recheckAI||Vector3.Distance(this.transform.position,agent.destination)<1)
		{
			//we'll determine how ghosts should move with some behaviour
			//that loosely mirrors some of the AI in the real pacman game!
			
			//This will be different for different types of ghost!
			switch(myType)
			{
				//The hunter is always trying to move towards pacman. You might need to tweak
				//the speed of this ghost if it's too hungry, it will move as directly towards the player as it can.
				case GhostType.Hunter:
					
					agent.destination = thePlayer.transform.position;
					
				break;
				
				//The drifter just moves entirely at random.
				case GhostType.Drifter:
					
					agent.destination = this.transform.position+(new Vector3(Random.Range(-5,6),0,Random.Range(-5,6)));
					
				break;
				
				//The ambusher moves entirely at random- until the player is nearby, then it rushes you!
				//We're recolouring it to make it clear what it's current plan is!
				case GhostType.Ambush:
					
					//close? Ambush!
					if(Vector3.Distance(thePlayer.transform.position,this.transform.position)<5)
					{
						this.GetComponent<Renderer>().material.color = Color.red;
						agent.destination = thePlayer.transform.position;
					}
					else //no player nearby? Random motion.
					{
						
						this.GetComponent<Renderer>().material.color = Color.green;
						agent.destination = this.transform.position+(new Vector3(Random.Range(-5,6),0,Random.Range(-5,6)));
					}
					
				break;
				
			}
			recheckTimer = 0;
		}
		
		
    }
	
	void OnCollisionEnter(Collision collisionData)
	{
		
		if(collisionData.gameObject.GetComponent<Pacman>()!=null)
		{
			//what should we do with the ghost
			//when they collide with a player?
		}
	}
	
	
}
