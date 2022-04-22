using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	
	//because we have some objects that shoot in a very similar way
	//we can use this script for both and avoid doubling up our code!
	
	
	public GameObject bulletPrefab;
	
	//how often can we fire?
	float shootTimer = 0.4f;
	float currentShootTimer=0;
	
	void FireBullet()
	{
		Bullet myBullet = Instantiate(bulletPrefab,this.transform.position+this.transform.up*1.5f,this.transform.rotation).GetComponent<Bullet>();
		myBullet.ownershipPlayer = true;
		
	}
	

    // Update is called once per frame
    void Update()
    {
		currentShootTimer+=Time.deltaTime;
        if(Input.GetAxis("Fire1")>0&&currentShootTimer>shootTimer)
		{
			FireBullet();
			currentShootTimer = 0;
		}
		
	}
}
