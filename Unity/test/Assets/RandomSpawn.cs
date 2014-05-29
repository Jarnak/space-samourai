using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {

	public GameObject LifeUp;
    public GameObject Ennemy;
	public float SpawnArea = 0.7f;
	//private GameObject myHudHandler;
	//private hudHandler hud; 
	private Quaternion zeroQuat = new Quaternion (0, 0, 0, 0); 
	private float popChance; 

	void Start () 
    {
		/* Bug on sait pas pourquoi
		myHudHandler = GameObject.FindGameObjectWithTag("HUD");
		Debug.Log (myHudHandler.name);
		hud = myHudHandler.GetComponent<hudHandler>();
		Debug.Log (hud.gameObject.name);
		*/

    }

	public void Spawn(GameObject tile)
    {
        //Debug.Log("in Spawn");
        for (int i = 0; i < 4; i++)
		{	
            int nbOfEnnemies = Random.Range(1, 2);
			if (GameObject.FindGameObjectWithTag("HUD").GetComponent<hudHandler>().getEnergy() > 100)
			{
				nbOfEnnemies = nbOfEnnemies * 2;
			}

            for (int j = 0; j < nbOfEnnemies; j++)
            {
                GameObject ennemy = Instantiate(Ennemy, new Vector3(tile.transform.position.x + (-15+8*i) + (Random.value*10)-5, 0.9f, (Random.value*2) - 1 ), zeroQuat) as GameObject;
                ennemy.transform.parent = this.transform;
            }
        }
		popChance = (100 - GameObject.FindGameObjectWithTag("HUD").GetComponent<hudHandler>().getHealth())/2;
		//Debug.Log (popChance);
		
		if (Random.Range (1,100) <= popChance)
			
		{
			GameObject lifeUp = Instantiate (LifeUp, new Vector3 (tile.transform.position.x + Random.Range (10,15), 1, tile.transform.position.z), zeroQuat) as GameObject;
			lifeUp.transform.parent = this.transform;
		}
    }
	// Update is called once per frame
	void Update () {

	}

	void OnDisable()
	{
		foreach (Transform child in this.transform) 
		{
			if (child.tag == "ennemy" || child.tag == "heal")
			{
				Destroy(child.gameObject);
			}
		}
	}
}
