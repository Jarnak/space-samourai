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
    Quaternion currentRot;
    private bool withAndroid;
    private Vector3 rot;
    private Vector3 rLeft = Vector3.right * 8;
    private Vector3 rRight = Vector3.left * 8;
    void Start()
    {
        withAndroid = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>().withAndroid();
        server = GameObject.FindGameObjectWithTag("Server");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!withAndroid)
        {
            rot = Vector3.zero;


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
            currentRot = new Quaternion(-data.z, data.x, data.y, data.w);
            transform.rotation = currentRot;
        }
    

    }

}