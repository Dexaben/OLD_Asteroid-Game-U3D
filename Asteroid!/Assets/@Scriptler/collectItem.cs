
using UnityEngine;

public class collectItem : MonoBehaviour {
	public string[] collectItemNames = {"bullet50","bullet100","hp50"};
	public string collecteditem;
	void Start () {
		int rand =Random.Range(0,4);
		switch(rand)
		{
			case 0:
				gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
				gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<enemlyWaypointScript>().objectName = "+50 Lazer Topu Mermisi";
				collecteditem = collectItemNames[rand];
				break;
			case 1:
				gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
				gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<enemlyWaypointScript>().objectName = "+100 Lazer Topu Mermisi";
				collecteditem = collectItemNames[rand];
				break;
			case 2:
				gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.green;
				gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<enemlyWaypointScript>().objectName = "+50 HP";
				collecteditem = collectItemNames[rand];
				break;
		}
	}

	void OnTriggerEnter(Collider player)
	{
		if(player.tag == "Player")
		{
				 switch(collecteditem)
				 {
					 case "bullet50":
					 		GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipController>().AMMO_DOLDUR(50);
							 Destroy(gameObject);
							 Debug.Log("Alindi");
					 	break;
					case "bullet100":
					 		GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipController>().AMMO_DOLDUR(100);
							  Destroy(gameObject);
							  Debug.Log("Alindi");
					 	break;
					case "hp50":
					 		GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipController>().HP_DOLDUR(50);
							  Destroy(gameObject);
							  Debug.Log("Alindi");
					 	break;
				 }
		}
		
	}
}
