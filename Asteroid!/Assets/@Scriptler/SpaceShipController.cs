using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class SpaceShipController : MonoBehaviour {
	[SerializeField] float hareketHizi = 40;
	[SerializeField] float donusHizi = 95;
	[SerializeField] Transform spaceship_Transform;
	[SerializeField] ParticleSystem burner;
	[SerializeField] UnityEngine.UI.Text AMMOtext;
	[SerializeField] UnityEngine.UI.Text HPtext;
	AudioSource audioSource;
	public int SpaceShipHP = 100;
	Color tempcolor;
	public int Ammo;
	void Awake () {
		Ammo = 9999999;
		SpaceShipHP = 10;
		HPtext.text = "HP : "+SpaceShipHP;
		audioSource = gameObject.GetComponent<AudioSource>();
		spaceship_Transform = this.transform;
		tempcolor = burner.startColor;
		AMMOtext.text ="Mermi : "+Ammo;
	}
	public void HPREFRESH()
	{
		HPtext.text = "HP : "+SpaceShipHP;
        if(SpaceShipHP <=0)
        {
            GameObject asteroidBoom;
            asteroidBoom = Resources.Load<GameObject>("GameObjects/AsteroidBoom") as GameObject;
            asteroidBoom.GetComponent<explodeAsteroid>().size = gameObject.transform.localScale.x;
            Instantiate(asteroidBoom, transform.position, transform.rotation);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FINISH_GAME();
        }
	}
	
	void Update()
	{
		Thrust();
		Turn();
		if(CrossPlatformInputManager.GetButton("Ates"))
		{
			AMMOtext.text ="Mermi : "+Ammo;
		
		}
	}
	public void AMMO_DOLDUR(int ammo_miktari)
	{
		Ammo+=ammo_miktari;
	}
	public void HP_DOLDUR(int hp_miktari)
	{
		SpaceShipHP+=hp_miktari;
	}
	void Turn()
	{
		float yaw = donusHizi * Time.deltaTime*CrossPlatformInputManager.GetAxis("Horizontal");
		float pitch = donusHizi * Time.deltaTime * CrossPlatformInputManager.GetAxis("Vertical");
     
		spaceship_Transform.Rotate(-pitch,yaw,-pitch/2);
	}
	void Thrust () {
	
			audioSource.pitch = CrossPlatformInputManager.GetAxis("Pitch")*2;
			transform.position += transform.forward * hareketHizi * Time.deltaTime * CrossPlatformInputManager.GetAxis("Pitch");
			if(CrossPlatformInputManager.GetAxis("Pitch") > 0)
			{
				if(burner.startSpeed <3) burner.startSpeed += 2*Time.deltaTime * CrossPlatformInputManager.GetAxis("Pitch");
				burner.startColor = tempcolor;
				if(Camera.main.fieldOfView <= 79) Camera.main.fieldOfView += 0.25f;
		
			}
			else if(CrossPlatformInputManager.GetAxis("Pitch")<0)
			{
				if(Camera.main.fieldOfView >= 69) Camera.main.fieldOfView -= 0.25f;
				burner.startSpeed = 1;
				burner.startColor = Color.cyan;
			}
			else
			{
				if(Camera.main.fieldOfView != 70)
				{
					if(Camera.main.fieldOfView < 70)
								Camera.main.fieldOfView += 0.25f;
					else Camera.main.fieldOfView -= 0.25f;
				}
				
				burner.startSpeed = 0.1f;
				burner.startColor = tempcolor;
			}
		
			

	}
}
