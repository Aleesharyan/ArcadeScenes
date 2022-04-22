using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWrap : MonoBehaviour
{
	
	//this script should be attached to ANYTHING that needs to loop around the screen-width
	//it works the same nomatter what sort of object it is!
	
	//map total distances
	float boundsVertical = 55;
	float boundsHorizontal = 90;

    // Update is called once per frame
    void FixedUpdate()
    {
		//where should we jump to? (assuming we need to)
		Vector3 teleportLocation = new Vector3(0,0,0);
		
		//you could do this in fewer lines of code but this is more readable!
		
		//if we are too far right
        if(this.transform.position.x>(boundsHorizontal/2))
		{
			//set our new location one screen-width to the left!
			teleportLocation.x-=boundsHorizontal-10;
		}
		
		if(this.transform.position.x<(-boundsHorizontal/2))
		{
			teleportLocation.x+=boundsHorizontal-10;
		}
		
		if(this.transform.position.y>(boundsVertical/2))
		{
			
			teleportLocation.y-=(boundsVertical-10);
		}
		
		if(this.transform.position.y<(-boundsVertical/2))
		{
			teleportLocation.y+=(boundsVertical-10);
		}
		
		if(teleportLocation!= new Vector3(0,0,0))
		{
			
			this.transform.position += teleportLocation;
		}
		
    }
}
