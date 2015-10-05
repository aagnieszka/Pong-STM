using UnityEngine;
using System.Collections;

public class Przeciwnik : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, 0, -12);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			transform.position = new Vector3(transform.position.x -1.0f,0.0f, transform.position.z);
		}		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.position = new Vector3(transform.position.x +1.0f,0.0f, transform.position.z);
		}		
	}
}
