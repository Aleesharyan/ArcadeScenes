using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacmanUI : MonoBehaviour
{
	public Text pipsText;
	public Text livesText;
	
	
	//a couple of handy UI functions- let's write events to subscribe them to!
	//Change the text for pips remaining
	void UpdatePips(int totalPips)
	{
		pipsText.text = ("Pips: "+totalPips);
		
	}
	//Change the text for lives remaining
	void UpdateLives(int totalLives)
	{
		livesText.text = ("Pips: "+totalLives);
		
	}
	
	//if you write more UI stuff, it could go here!
	
	
}
