using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {


    public hudHandler hud;
	private GameObject myBody;
    

	// Use this for initialization
	void Start () 
    {	
		hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<hudHandler>();
		myBody = transform.Find ("ninjeuboom").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "sabre")
        {
            hud.pointInc(50);
			hud.stockEnergy(10);
			this.GetComponent<BoxCollider>().size = Vector3.zero;
			myBody.transform.FindChild("Group20682").GetComponent<MeshRenderer>().enabled=false;
			myBody.GetComponent<Animator>().SetTrigger("die");
			audio.Play();
			Destroy(this.gameObject, 1f);
            
        }
    }
	public void launch ()
	{

	}
}
