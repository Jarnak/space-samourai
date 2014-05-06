using UnityEngine;
using System.Collections;

public class WrenchLauncher : MonoBehaviour {

	public GameObject target;
	public Rigidbody prefab;
	public float targetTime;
    private Vector3 vToPlyr;
	// Use this for initialization
	void Start () 
    {	
		targetTime =1;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
      
        vToPlyr = new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z );
        
    if (transform.position.x > target.transform.position.x )
    {
        if (Vector3.Distance(vToPlyr, Vector3.zero) < 20)
        {


            if (targetTime < Time.time)
            {   
                
                Rigidbody clone = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody;
                targetTime = Time.time + 4;
                //float launchOffset = Random.value - 0.5f;
                //vToPlyr = vToPlyr + launchOffset * Vector3.forward;
                vToPlyr = Vector3.Normalize(vToPlyr);
                clone.transform.parent = this.transform;
                clone.velocity = vToPlyr * 10;
                Destroy(clone.gameObject, 5);
            }
        }
    }
	}
}
