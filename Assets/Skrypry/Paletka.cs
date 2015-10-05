using UnityEngine;
using System.Collections;

public class Paletka : MonoBehaviour
{
    //maksymalne wychylenie paletki 
    public float wychylenie;
	void OnCollisionEnter(Collision kolizja)
	{
		if (kolizja.gameObject.name == "Sphere")
		{
			GetComponent<AudioSource>().Play();
		}
		
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (transform.localPosition.x > wychylenie) transform.localPosition = new Vector3(wychylenie,transform.localPosition.y,transform.localPosition.z);
	    if (transform.localPosition.x < -wychylenie) transform.localPosition = new Vector3(-wychylenie, transform.localPosition.y, transform.localPosition.z);
        
	}
}
