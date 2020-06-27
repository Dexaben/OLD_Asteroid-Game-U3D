using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class asteroidMoment : MonoBehaviour {
   
    public Transform target;
    private GameObject asteroidBoom;
    [SerializeField] int HP;
    int asteroidHizi;
    void Start()
    {
        HP = 100;
        asteroidBoom = Resources.Load<GameObject>("GameObjects/AsteroidBoom")as GameObject;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        string[] asteroidssize= {"min","med","big","max"};//boyut
        int rand = Random.Range(0, asteroidssize.Length);

        switch (asteroidssize[rand])
        {
            case "min":
                transform.localScale = new Vector3(1, 1, 1) * 10;
                HP =140;
                break;
            case "med":
                transform.localScale = new Vector3(1, 1, 1) * 14;
                HP =200;
                break;
            case "big":
                transform.localScale = new Vector3(1, 1, 1) * 16;
                HP =270;
                break;
            case "max":
                transform.localScale = new Vector3(1, 1, 1) * 20;
                HP =350;
                break;
                

        }

        string[] asteroidshız = { "yavas", "ort", "hiz", "cokhiz" };//hız
        int rand2 = Random.Range(0, asteroidshız.Length);

        switch (asteroidshız[rand2])
        {

            case "yavas":
                
                asteroidHizi = 10;
                break;
            case "ort":
                 asteroidHizi = 15;
                break;
            case "hiz":
                 asteroidHizi = 20;
                break;
            case "cokhiz":
                 asteroidHizi = 35;
                
                break;

        }
    }
    void OnTriggerEnter(Collider other)
    {
         GameObject hpBar = Resources.Load<GameObject>("GameObjects/hpBar") as GameObject;
        
        if(other.tag == "Bullet")
        {
            HP-=30;
            if(HP <= 0)
            {
                BULLETBOOM();
                hpBar.transform.GetChild(0).GetComponent<UnityEngine.UI.Slider>().value = 0;
                
                return;
            }
           
            hpBar.transform.GetChild(0).GetComponent<UnityEngine.UI.Slider>().value = (float)HP/100f;
       
            Destroy(Instantiate(hpBar,transform.position,transform.rotation),1.5f);
        }
         if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            player.GetComponent<SpaceShipController>().SpaceShipHP -= 5;
             player.GetComponent<SpaceShipController>().HPREFRESH();
             Camera.main.gameObject.GetComponent<ScreenShaker>().Shake(0.1f,1f);
            Boom();
        }
    
        
    }
    void BULLETBOOM()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ASTEROID_PATLATILDI(true);
        asteroidBoom.GetComponent<explodeAsteroid>().size = gameObject.transform.localScale.x;
        Instantiate(asteroidBoom, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void Boom()
    {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ASTEROID_PATLATILDI(false);
           
        asteroidBoom.GetComponent<explodeAsteroid>().size = gameObject.transform.localScale.x;
        Instantiate(asteroidBoom,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    void LateUpdate()
    {
        if(target != null)
        {
            if (transform.position != target.position) // geminin transformuna eşit değilse gelmeye devam etsin.
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target.position, asteroidHizi * Time.deltaTime); //asteroid hızı!
                GetComponent<Rigidbody>().MovePosition(pos);
            }
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
}

