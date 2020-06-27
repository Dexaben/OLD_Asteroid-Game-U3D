using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class GunShoot : MonoBehaviour {
	[SerializeField] GameObject bullet;
	[SerializeField] float destroyingTimeBullet = 3f;
	[SerializeField] AudioClip audioClip;
	[SerializeField] AudioSource audioSource;
	bool readyForFire;
	void Start () {
		readyForFire = true;
	}
	void Update () {
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipController>().Ammo <= 0)
		{
			readyForFire = false;

		}
		if(CrossPlatformInputManager.GetButton("Ates"))
		{
			if(readyForFire)
			{
				Camera.main.gameObject.GetComponent<ScreenShaker>().Shake(0.001f,0.04f);
				GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipController>().Ammo -= 1;
				audioSource.PlayOneShot(audioClip);
				Destroy(Instantiate(bullet,transform.position,transform.rotation),destroyingTimeBullet);
				readyForFire = false;
				StartCoroutine("freeze");
			}
		
		}
	}
	IEnumerator freeze()
	{
		yield return new WaitForSeconds(0.15f);
		readyForFire = true;
	}
}
