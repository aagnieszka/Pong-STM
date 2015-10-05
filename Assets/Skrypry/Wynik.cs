using UnityEngine;
using System.Collections;


public class Wynik : MonoBehaviour {

	public static int WynikGracza =0;
	public static int WynikPrzeciwnika = 0;




	public void ZwiekszWynik(int KtoryGracz)
	{

		if (KtoryGracz == 1) {
			WynikGracza++;
			GetComponent<TextMesh>().text = ("Gracz: "+ WynikGracza.ToString() + " Przeciw: "+WynikPrzeciwnika.ToString());


		} else if (KtoryGracz == 2) {
			WynikPrzeciwnika ++;
			GetComponent<TextMesh>().text = ("Gracz: "+ WynikGracza.ToString() + " Przeciw: "+WynikPrzeciwnika.ToString());
		}
		if (WynikPrzeciwnika > 9) {
			Application.LoadLevel(2);
		}
		if(WynikGracza>9){
			Application.LoadLevel (3);
		}
	}


}
