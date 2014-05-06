using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    private GameObject farTile;
    private GameObject nextTile;
    private GameObject tile;
    private Vector3 direction = Vector3.left;
    private bool isRotating = false;
    private float targetAngle;
    private float currentAngle =0f;
    private int nbrTile;
	private int tileSpeed;
	private int speedOffSet;
	// Use this for initialization 
	void Start () 
    {
        nbrTile = 0;
        farTile = MapPool.getMap();
        farTile.SetActive(true);
        farTile.SendMessage("Spawn", farTile);
        nextTile = MapPool.getMap();
        nextTile.SetActive(true);
        nextTile.SendMessage("Spawn", nextTile);
        tile = MapPool.getMap();
        tile.SetActive(true);
        tile.transform.position = new Vector3(25, 0, 0);
        nextTile.transform.position = new Vector3(75, 0, 0);
        farTile.transform.position = new Vector3(125, 0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		tileSpeed = nbrTile / 8;
		
		if (tileSpeed > 5) 
		{
			tileSpeed = 5;
		}
		
		speedOffSet = 6;
		farTile.transform.position += direction * (speedOffSet + tileSpeed) * Time.deltaTime;
		nextTile.transform.position += direction * (speedOffSet + tileSpeed) * Time.deltaTime;
		tile.transform.position += direction * (speedOffSet + tileSpeed)* Time.deltaTime;
		

   
	}

	void OnTriggerEnter(Collider coll) 
    {

            if (coll.tag =="NewTile")
            {
                enterNewTile();
            }

	}

    /* Inutile si on tourne pas 
    public void rTurn()
    {
        if (direction == Vector3.left) 
        {
            direction = Vector3.forward;
        }
        else
        {
            if (direction == Vector3.forward)
            {
                direction = Vector3.right;
            }
            else
            {
                if (direction == Vector3.right)
                {
                    direction = Vector3.back;
                }
                else
                {
                    direction = Vector3.left;
                }
            }

        }
        isRotating = true;
        targetAngle = 90;
    }

    public void lTurn()
    {
        if (direction == Vector3.left)
        {
            direction = Vector3.back;
        }
        else
        {
            if (direction == Vector3.back)
            {
                direction = Vector3.right;
            }
            else
            {
                if (direction == Vector3.right)
                {
                    direction = Vector3.forward;
                }
                else
                {
                    direction = Vector3.left;
                }
                
            }
        }
        isRotating = true;
        targetAngle = -90;
       
    }

    void playerRotate ()
    {
        if (currentAngle <= Mathf.Abs(targetAngle))
        {
            transform.Rotate(new Vector3(0, targetAngle *2* Time.deltaTime, 0));
            currentAngle = currentAngle + 180 * Time.deltaTime;
        }
        else
        {
            isRotating = false;
            currentAngle = 0f;
        }
    }
    */
    void enterNewTile()
    {
        nbrTile++;
		GameObject nTile = MapPool.getMap();
        tile.SetActive(false);
        tile = nextTile;
        nextTile = farTile;
        farTile = nTile;
        farTile.transform.position = new Vector3(nextTile.transform.position.x + 50, 0, 0 - nextTile.GetComponent<TilePos>().zIn + nextTile.GetComponent<TilePos>().zOut - farTile.GetComponent<TilePos>().zIn);
        farTile.SetActive(true);
        farTile.SendMessage("Spawn", farTile);
    }

	public void resetGame()
	{
		tile.SetActive (false);
		nextTile.SetActive (false);
		farTile.SetActive (false);

		nbrTile = 0;
		farTile = MapPool.getMap();
		farTile.SetActive(true);
		farTile.SendMessage("Spawn", farTile);
		nextTile = MapPool.getMap();
		nextTile.SetActive(true);
		nextTile.SendMessage("Spawn", nextTile);
		tile = MapPool.getMap();
		tile.SetActive(true);
		tile.transform.position = new Vector3(25, 0, 0);
		nextTile.transform.position = new Vector3(75, 0, 0);
		farTile.transform.position = new Vector3(125, 0, 0);
	}
}
