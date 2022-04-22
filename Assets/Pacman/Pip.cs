using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.cyan;
    }

	void OnTriggerEnter(Collider collisionData)
	{
		//check if the collision was with the player
		if(collisionData.gameObject.GetComponent<Pacman>()!=null)
		{
			//something goes here to
			//trigger an event?
			//This event will add to the score, update the UI, check to see if all the pips have been eaten
			//But it won't do it here- we'll just trigger the event!
			
			//and then destroy this object
			Destroy(this.gameObject);
			
			
		}
	}
	
	
}
