using UnityEngine;
using System.Collections;

public class MapPoolTester : MonoBehaviour {


    private int mapCount = 0;
    private GameObject obj1;
    private GameObject obj2;
    
    // Use this for initialization
	void Start () 
    
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    
    {
	    if (Input.GetMouseButtonDown(1))
        {
            if (mapCount == 2)
            {
                GameObject obj = MapPool.getMap();
                obj1.SetActive(false);
                obj1 = obj2;
                obj1.transform.position = Vector3.zero;
                obj2 = obj;
                obj2.transform.position = new Vector3(5, 0, 0);
                obj2.SetActive(true);
            }
            
            if (mapCount == 1)
            {
                obj2 = MapPool.getMap();
                obj2.transform.position = new Vector3(5, 0, 0);
                obj2.SetActive(true);
                mapCount++;
            }
            
            if (mapCount == 0)
            {
                obj1 = MapPool.getMap();
                obj1.transform.position = Vector3.zero;
                obj1.SetActive(true);
                mapCount++;
            }
       }
	}
}
