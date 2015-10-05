using UnityEngine;
using System.Collections;

public class Pilka : MonoBehaviour {
	float los2,los;
	public int PozycjaGracza = 1;
	public int ileOdbic;
	public Collision odbicie;
	// Use this for initialization
	public Rigidbody rb;

	void OnCollisionEnter(Collision kolizja)
	{
		if (kolizja.gameObject.name == "Przeciwnik")
		{
			
			rb.AddForce(new Vector3(0f,0f,ileOdbic));
			ileOdbic++;
			print(ileOdbic);
			
		}
		else if (kolizja.gameObject.name == "Gracz")
		{
			rb.AddForce(new Vector3(0, 0, -(ileOdbic)));
			ileOdbic++;
			
			print(ileOdbic);
		}
		
	}
	void Start () {

		ileOdbic =0;
		PozycjaGracza = 1;
		los = Random.Range (0, 2) == 0 ? -1 : 1; // jeżeli == 0 to -1 inaczej 1 
		los2 = Random.Range (0, 2) == 0 ? -1 : 1;


		rb.velocity = new Vector3 (Random.Range(5,10)*los2, 0.0f, (4.0f +ileOdbic)*los );
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.z < (-12.5)) {   //wylecenie pilki poza plansze/paletke
			GameObject.Find("Text").GetComponent<Wynik>().ZwiekszWynik(1);
			transform.position = Vector3.zero;
			Start ();
			if (ileOdbic<10){
			ileOdbic++;
			}
		}	
		if (transform.position.z > (12.5)) {
			GameObject.Find("Text").GetComponent<Wynik>().ZwiekszWynik(2);
			transform.position = Vector3.zero;
			Start ();
			if (ileOdbic<10){
				ileOdbic++;
			}

		}	
	}


}
