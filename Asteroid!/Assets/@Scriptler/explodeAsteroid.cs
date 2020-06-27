using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeAsteroid : MonoBehaviour {
	public float destroyDelay;
	public float minForce;
	public float maxForce;
	public float radius;
	public float size;

	void Start () {
			Explode();

				gameObject.transform.localScale = new Vector3(size,size,size);
			InvokeRepeating("scaleDown",0,0.05f);
	}
	void Explode () {
		foreach (Transform t in transform)
		{
			var rb = t.GetComponent<Rigidbody>();
			if(rb != null)
			{
				rb.AddExplosionForce(Random.Range(minForce,maxForce),transform.position,radius);
			}
		
		}

	}
	void scaleDown()
	{

		if(gameObject.transform.GetChild(0).localScale.x >= 0)
		{
			for(int i = 0;i<gameObject.transform.childCount;i++)
			{
				if(gameObject.transform.GetChild(i).localScale.x >= 0)
				gameObject.transform.GetChild(i).localScale = new Vector3(gameObject.transform.GetChild(i).localScale.x-0.2f,gameObject.transform.GetChild(i).localScale.y-0.2f,gameObject.transform.GetChild(i).localScale.z-0.2f);
			}
			
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
