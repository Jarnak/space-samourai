using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {


    public GameObject Ennemy;
	public float SpawnArea = 1;
	private GameObject[] ennemySpawns;
	public GameObject popEnnemyPoint;
	private Quaternion zeroQuat = new Quaternion (0, 0, 0, 0); 

	void Start () 
    {
		/*// On crée au préalable un empty gameobject nommé "popEnnemyPoint".
		GameObject Spawn1 = Instantiate (popEnnemyPoint, new Vector3 (10, 0, 0), zeroQuat) as GameObject;
        Spawn1.transform.parent = this.transform;

		GameObject Spawn2 = Instantiate (popEnnemyPoint, new Vector3 (20, 0, 0), zeroQuat) as GameObject;
        Spawn2.transform.parent = this.transform;

		GameObject Spawn3 = Instantiate (popEnnemyPoint, new Vector3 (30, 0, 0), zeroQuat) as GameObject;
        Spawn3.transform.parent = this.transform;

		GameObject Spawn4 = Instantiate (popEnnemyPoint, new Vector3 (40, 0, 0), zeroQuat) as GameObject;
        Spawn4.transform.parent = this.transform;
		*/

       
		//ennemySpawns = GameObject.FindGameObjectsWithTag ("EnnemySpawnPoint");
    }

	public void Spawn(GameObject tile)
    {
        //Debug.Log("in Spawn");
        for (int i = 0; i < 4; i++)
        {
            int nbOfEnnemies = Random.Range(0, 3);
            for (int j = 0; j < nbOfEnnemies; j++)
            {
                GameObject ennemy = Instantiate(Ennemy, new Vector3(tile.transform.position.x + (-15+10*i) + (Random.value*10)-5, 1, (Random.value*2) - 1 ), zeroQuat) as GameObject;
                ennemy.transform.parent = this.transform;
            }
        }
    }
	// Update is called once per frame
	void Update () {

	}
}
