using UnityEngine;
using System.Collections;

public class sciana : MonoBehaviour {
	
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision kolizja)
	{
		if (kolizja.gameObject.name == "Sphere")
		{
			GetComponent<AudioSource>().Play();
		}
		
		
	}
}
