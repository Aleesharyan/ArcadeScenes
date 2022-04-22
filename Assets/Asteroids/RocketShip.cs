using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
	

	public float thrustSpeed;
	//how fast can we move?
	
	public float topSpeed;
	
	public float rotationSpeed;
	//how fast can we turn?
	
	
	Rigidbody rb;
	

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // FixedUpdate is called on every 'physics' update- about every 0.1 of a second by default
	//movement with Rigidbody just sort of flies better if it's all managed on fixedUpdate!
    void FixedUpdate()
    {
        			
		//Rocketship movement!
		//A rocket has rotation (or 'torque') and thrust.
		//traditionally on the arcade versionwe'd only be able to thrust forwards
		//but let's be generous and allow backwards movement too!
		
		//Let's handle rotation first. We *could* use Rigidbody.AddTorque(V3) for this- a physics turn-
		//but you tend to get some weird results with player input and it can be hard to control as it spins up.
		//Instead let's just rotate the object directly through the transform.
		
		//this object  rotate it around the z axis   using hoz input   vs game timer
		this.transform.Rotate(Vector3.forward*Input.GetAxis("Horizontal")*rotationSpeed*-10*Time.deltaTime);
		
		//This won't affect/be affected by physics, but it will change the direction of the object
		//when we want to thrust forwards- it'll be a new 'forwards'!
		//if we want to rotate faster, we'll send a bigger number through directionInput
		
		//and now thrust!
		//We can use our Rigidbody pretty directly here- we just tell it to push!
		rb.AddForce(this.transform.up*Input.GetAxis("Vertical")*thrustSpeed*10*Time.deltaTime);

    }
	
	void OnCollisionEnter(Collision collisionData)
	{
		if(collisionData.gameObject.GetComponent<Asteroid>()!=null)
		{
			//Ooh! We bumped into an asteroid!
			//Probably an event could handle this?
			//and you'll need to write code for what happens re: lives and UI!
		}
	}
	
	
}
