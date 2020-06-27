
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemlyWaypointScript : MonoBehaviour {
 public Image img;
 public string objectName = "Lazer Topu Mermisi";
 public Transform target;
 public Text meterText;


void Start()
{
    
 
    if(gameObject.tag == "bulletWaypoint")
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Textureler/bulletWaypoint") as Sprite;
        GetComponent<Image>().color = Color.blue;
       
    }
    
    if(gameObject.tag == "enemlyWaypoint")
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Textureler/enemlyWaypoint") as Sprite;
        GetComponent<Image>().color = Color.white;
    } 

}
 void Update()
 {
       
	 	float minX = img.GetPixelAdjustedRect().width /2;
        float maxX = Screen.width -minX;

        float minY = img.GetPixelAdjustedRect().height /2;
        float maxY = Screen.height -minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);
        if(Vector3.Dot((target.position-Camera.main.transform.position),Camera.main.transform.forward)<0)
        {
            img.enabled = true;
            meterText.enabled = true;
            if (pos.x <Screen.width/2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
            if (pos.y < Screen.height / 2)
            {
                pos.y = maxY;
            }
            else
            {
                pos.y = minY;
            }
        }
        
        pos.x = Mathf.Clamp(pos.x,minX,maxX);
        pos.y = Mathf.Clamp(pos.y,minY,maxY);

        img.transform.position = pos;
		if(Vector3.Distance(target.position,Camera.main.transform.position) > 2000)
		{
			img.rectTransform.localScale = new Vector3(0,0,0);    
		}
        else if(Vector3.Distance(target.position,Camera.main.transform.position) < 800 && gameObject.tag == "enemlyWaypoint")
        {
            meterText.text = ("ALERT\n"+(int)Vector3.Distance(target.position,Camera.main.transform.position)).ToString() +"m";
            img.rectTransform.localScale = new Vector3((2000f-Vector3.Distance(target.position,Camera.main.transform.position))/2000,(2000f-Vector3.Distance(target.position,Camera.main.transform.position))/2000,0);     
            ALERTENEMLY();
        }
        else if(gameObject.tag == "bulletWaypoint")
        {
            meterText.text = (objectName+"\n"+(int)Vector3.Distance(target.position,Camera.main.transform.position)).ToString() +"m";
            img.rectTransform.localScale = new Vector3((2000f-Vector3.Distance(target.position,Camera.main.transform.position))/2000,(2000f-Vector3.Distance(target.position,Camera.main.transform.position))/2000,0);     
        }
        else{
		img.rectTransform.localScale = new Vector3((2000f-Vector3.Distance(target.position,Camera.main.transform.position))/2000,(2000f-Vector3.Distance(target.position,Camera.main.transform.position))/2000,0);     
            meterText.text = ((int)Vector3.Distance(target.position,Camera.main.transform.position)).ToString() +"m";
		}
        
		
 }
        void ALERTENEMLY()
        {
         
            GetComponent<Image>().color = Color.Lerp(Color.black, Color.red, Mathf.PingPong(Time.time, 1));
        }
}
