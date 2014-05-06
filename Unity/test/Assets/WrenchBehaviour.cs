using UnityEngine;
using System.Collections;

public class WrenchBehaviour : MonoBehaviour {


    public GameObject hud;
    bool hit = false;
	Vector3 rotation = new Vector3(0,10,0);
    private bool withAndroid = false;
	public AudioClip cling1;
	public AudioClip cling2;
	public AudioClip cling3;
	public AudioClip hurted;
	private AudioClip[] audioClips = new AudioClip[3];
	void Start ()
    {	
		audioClips [0] = cling1;
		audioClips [1] = cling2;
		audioClips [2] = cling3;
        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            withAndroid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>().withAndroid();
        }
        hud = GameObject.FindGameObjectWithTag("HUD");
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(rotation);
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "sabre" & hit == false)
        {
            this.rigidbody.useGravity = true;
            rotation = new Vector3(0, 0, 0);
            hit = true;
            hud.GetComponent<hudHandler>().pointInc(10);
			hud.GetComponent<hudHandler>().stockEnergy(2);
			int i = (int) Random.Range(0,2);
			audio.clip = audioClips[i];
			audio.Play();
            if (withAndroid)
            {
                GameObject.FindGameObjectWithTag("Server").SendMessage("sendHit");
            }

        }

        if (coll.transform.tag == "Player" && hit == false)
        {	 
			coll.gameObject.SendMessage("hurted");
			//PlayerHandler PH = coll.gameObject.GetComponent<PlayerHandler>();
			//PH.hurted();
			Destroy(this.gameObject);
            //hud.GetComponent<hudHandler>().healthDown(10);
            
        }
        
    }
}
