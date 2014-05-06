using UnityEngine;
using System.Collections;

public class MapPool : MonoBehaviour {

    // On entre manuellement les différentes map à mettre dans la pool
    
    public GameObject tile;
    public int poolAmount = 5;

    private static GameObject[] mapPool;
    
	void Start () 
    
    {
        mapPool = new GameObject[poolAmount];
		for (int i = 0; i<poolAmount; i++) 
		{
			mapPool[i] = (GameObject) Instantiate(tile);
			mapPool[i].SetActive(false);
			mapPool[i].transform.parent = this.transform;
		}
	}
	
    public static GameObject getMap()
    {
        int rd = Random.Range(0, 5);
        if (!mapPool[rd].activeInHierarchy)
        {
            return mapPool[rd];
        }
        else
        {
            return getMap();
        }
    }


}
