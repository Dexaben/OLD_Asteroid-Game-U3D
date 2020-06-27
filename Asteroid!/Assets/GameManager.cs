using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public int AsteroidSayisi=0;
    public float asteroidSpawnTime = 0.0f;
    public int maxAsteroidSpawnValue = 0;
    public int destroyedAsteroid =0;
	void Start () {
        AsteroidSayisi = 0;
        asteroidSpawnTime = 20f;
        maxAsteroidSpawnValue = 10;
        destroyedAsteroid = 0;
        ASTEROID_SPAWN(1);
        InvokeRepeating("ASTEROID_SPAWN",0,asteroidSpawnTime);
	}
   public void FINISH_GAME()
    {
        CancelInvoke("ASTEROID_SPAWN");
    }
    void ASTEROID_SPAWN()
    {
        Debug.Log("spawned");
            AsteroidSayisi += 1;
            GameObject prefab = Resources.Load<GameObject>("GameObjects/Asteroid") as GameObject;
            Vector3 center = GameObject.FindGameObjectWithTag("Player").transform.position;
            int rand_radius = Random.Range(700, 900);
            Vector3 pos = RandomCircle(center, rand_radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, rot);
    
    }
    void ASTEROID_SPAWN(int spawnValue)
    {
        for(int i = 0;i<spawnValue;i++)
        {
            AsteroidSayisi += 1;
            GameObject prefab = Resources.Load<GameObject>("GameObjects/Asteroid") as GameObject;
            Vector3 center = GameObject.FindGameObjectWithTag("Player").transform.position;
            int rand_radius = Random.Range(700,1000);
            Vector3 pos = RandomCircle(center, rand_radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, rot);
        }
    }
	void Update () {
		
	}
    public void ASTEROID_PATLATILDI(bool destroyed)
    {
        if(destroyed) destroyedAsteroid++;
        AsteroidSayisi -= 1;
        if(AsteroidSayisi < maxAsteroidSpawnValue)
        {
            ASTEROID_SPAWN(1);
        }
   
    }
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
