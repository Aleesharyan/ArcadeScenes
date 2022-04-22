using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public bool ownershipPlayer;
	public float speed;
	
	void Update()
	{
		
		
		if(ownershipPlayer)
		{
			this.transform.position+=this.transform.up*speed*Time.deltaTime;
			
		}
		else
		{
			this.transform.position-=this.transform.up*speed*Time.deltaTime;
		}
	}
	
	
}
