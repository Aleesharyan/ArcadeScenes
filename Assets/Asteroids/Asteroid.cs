using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	Rigidbody rb;
	public float startingForce;
	public int iteration = 1;
	
	
    // Start is called before the first frame update
    void Start()
    {
       
		//how many times have we been divided? We need to scale based on this-
		//if we're not an original asteroid, this will have been set by our 'parent' asteroid in Divide.
		this.transform.localScale = new Vector3(10/iteration,10/iteration,10/iteration)*1.5f;
		
		//We've been spawned! It's OK if we're not moving a lot on start, we'll get a push every time we divide or bonk into other things.
		rb = this.GetComponent<Rigidbody>();
		rb.AddForce(new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0)*startingForce*(10-iteration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collisionData)
	{
		
		if(collisionData.gameObject.GetComponent<Bullet>()!=null)
		{
			Destroy(collisionData.gameObject);
			Divide();
		}
	}
	
	
	void Divide()
	{
		//check if we're not too small to split:
		if(iteration<7)
		{
			//Time to split!
			//create two duplicates of this astroid very close, and make sure they know their (new) iteration number.
			
			for(int i = 0; i<2; i++)
			{
				Asteroid a = Instantiate(this.gameObject,this.transform.position+new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f),0),this.transform.rotation).GetComponent<Asteroid>();
				a.iteration = iteration+1; //my iteration plus two!
			}
		}
		
		
		
		//and delete this asteroid! You may also want to use an event call here for score/fx etc?
		Destroy(this.gameObject);
		
	}
	
	
}
