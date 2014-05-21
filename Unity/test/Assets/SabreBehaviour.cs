using UnityEngine;
using System.Collections;

public class SabreBehaviour : MonoBehaviour
{

    //Vector3 rLeft = new Vector3(4, 0, 0);
    //Vector3 rRight = new Vector3(-4, 0, 0);
    //Vector3 rUp = new Vector3(0, 0, 2);
    //Vector3 rDown = new Vector3(0, 0, -2);
    //Vector3 rot = Vector3.zero;
    public GameObject server;
    private DATA data;
    private Quaternion currentRot;
    private bool withAndroid;
    private Vector3 rot;
    private Vector3 rLeft = Vector3.right * 8;
    private Vector3 rRight = Vector3.left * 8;
    void Start()
    {
        withAndroid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>().withAndroid();
        server = GameObject.FindGameObjectWithTag("Server");
		transform.rotation = Quaternion.AngleAxis(-30, Vector3.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!withAndroid)
        {
            rot = Vector3.zero;
			//Debug.Log (this.transform.rotation);


            if (Input.GetKey("left"))
            {


                if (transform.rotation.eulerAngles.x < 40 || transform.rotation.eulerAngles.x > 260)
                {
                    rot += rLeft;
                }


            }
            if (Input.GetKey("right"))
            {
                if (transform.rotation.eulerAngles.x > 320 || transform.rotation.eulerAngles.x < 100)
                {
                    rot += rRight;
                }

            }

            this.transform.Rotate(rot);

        }
        if (withAndroid)
        {	
            data = server.GetComponent<ServerHandler>().getData();
			//currentRot = new Quaternion( data.x , data.y, data.z, data.w);
			currentRot = Quaternion.identity;
			Debug.Log(currentRot);
			this.transform.rotation = currentRot;
			float EulerCurrentx = currentRot.eulerAngles.x;
			float EulerCurrenty = currentRot.eulerAngles.y;
			float EulerCurrentz = currentRot.eulerAngles.z;
			Debug.Log("x");
			Debug.Log( EulerCurrentx);
			Debug.Log ( " y ");
			Debug.Log ( EulerCurrenty);
			Debug.Log (" z ");
			Debug.Log(  EulerCurrentz);
			//transform.rotation = Quaternion.Euler(new Vector3(EulerCurrentx, 0, EulerCurrentz));
            //float EulerCurrenty = currentRot.eulerAngles.y;
			//float toChangex = transform.rotation.eulerAngles.x - EulerCurrentx;
            //float toChangey = transform.rotation.eulerAngles.y - EulerCurrenty;
			//transform.rotation = Quaternion.AngleAxis( EulerCurrentx , Vector3.left);
            //transform.Rotate(new Vector3(0, 0, -20)); 
        }
		//data = server.GetComponent<ServerHandler>().getData();
		//currentRot = new Quaternion(data.x,data.y,-data.z, data.w);
		//currentRot = new Quaternion(1,0,0,1);

    }

}