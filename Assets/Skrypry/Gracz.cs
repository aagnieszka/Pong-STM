using UnityEngine;
using System.Collections;

public class Gracz : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision kolizja)
	{
		if (kolizja.gameObject.name == "Sphere")
		{
			GetComponent<AudioSource>().Play();
		}
		
		
	}
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		transform.position = new Vector3 (ray.GetPoint(10f).x, 0.0f, transform.position.z);
	
	}
}
