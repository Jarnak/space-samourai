using UnityEngine;
using System.Collections;
using System.Net;

public class GameHandler : MonoBehaviour
{
    // Random Variable


    public GameObject game;

    public GameObject server;

    private bool launched = false;

    DATA data;

    private bool iWantToPlayWithAndroid;

    private bool iWantToPlayWithoutAndroid;

    private bool connected = false;

    private string adresseIP = Dns.Resolve(Dns.GetHostName()).AddressList[0].ToString();

    private bool showMenu = false;

    private bool isDead = false;

	private bool onPause = false;

    private hudHandler myHudHandler;

    private GameObject currentGame;


    // GUI variable

    private Rect inputChoiceWindowRect;

    private int inputChoiceWindowWidth = 400;

    private int inputChoiceWindowHeight = 280;

    private int buttonHeight = 60;

    private int leftIndent;

    private int topIndent;

    private Rect deadWindowRect;

    private int deadWindowWidth = 400;

    private int deadWindowHeight = 140;
	 



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
		if (launched == true) 
        {	
			if (Input.GetKeyDown(KeyCode.Escape) && onPause == true)
			{
				Time.timeScale = 1f;
				onPause = false;
			}
			if (Input.GetKeyDown(KeyCode.Escape) && onPause == false)
			{
				onPause = true;
				Time.timeScale = 0f;

			}

			
		
			if (myHudHandler.getHealth () == 0) 
            {	
				isDead = true;
			}

            
			if (isDead == true) 
            {
				Time.timeScale = 0f;
            }

        }
    }

     void deadWindow(int windowID)
    {
        GUILayout.Space(15);
        GUILayout.Label("Vous êtes mort");
        GUILayout.Label("Score :" + myHudHandler.getScore().ToString());
        if (GUILayout.Button("Rejouer", GUILayout.Height(buttonHeight)))
        {	
			myHudHandler.setHealth(100);
			GameObject.FindGameObjectWithTag("Player").SendMessage("resetGame");
			myHudHandler.setScore(0);
            myHudHandler.loseEnergy(150);
			Time.timeScale=1f;
			isDead = false;
        }

    }

	void pauseWindow(int windowID)
	{
		GUILayout.Space(15);
		GUILayout.Label("Jeu en pause");
		GUILayout.Label("Score actuel :" + myHudHandler.getScore().ToString());
		if (GUILayout.Button("Reprendre", GUILayout.Height(buttonHeight)))
		{	
			onPause = false;
			Time.timeScale = 1f;
		}
        if (GUILayout.Button("Quitter", GUILayout.Height(buttonHeight)))
        {
            Application.Quit();
        }
		
	}

    void inputChoiceWindow(int windowID)
    {
        GUILayout.Space(15);

        if (iWantToPlayWithAndroid == false && iWantToPlayWithoutAndroid == false)
        {
            GUILayout.Label("Bienvenue dans Space Samourai");
            GUILayout.Label("Choisissez comment vous voulez jouer");

            GUILayout.Space(15);

            if (GUILayout.Button("Jouer avec Android", GUILayout.Height(buttonHeight)))
            {
                iWantToPlayWithAndroid = true;
                server = (GameObject)Instantiate(server);


            }

            GUILayout.Space(10);

            if (GUILayout.Button("Jouer sans Android", GUILayout.Height(buttonHeight)))
            {
                

				iWantToPlayWithoutAndroid = true;
                launched = true;
                currentGame = (GameObject)Instantiate(game);
				Time.timeScale = 1f;
				myHudHandler = GameObject.FindGameObjectWithTag ("HUD").GetComponent<hudHandler>();
                // on instancie le jeu;
            }

        }

        if (iWantToPlayWithAndroid == true)
        {

            if (connected == true)
            {
                data = server.GetComponent<ServerHandler>().getData();
                if (data.go == true)
                {
                    if (!launched)
                    {
                        // on lance le jeu avec android
                        launched = true;
                        currentGame = (GameObject)Instantiate(game);
						Time.timeScale = 1f;
						myHudHandler = GameObject.FindGameObjectWithTag ("HUD").GetComponent<hudHandler>();
                    }

                }
                else
                {
                    GUILayout.Label(" Vous etes connecté, cliquer pour commencer ");
                }

            }
            else
            {
                GUILayout.Label(" Connectez vous à l'adresse IP : " + adresseIP + " sur le port 3000");
            }
        }
    }

    void OnGUI()
    {
        if (launched == false && isDead == false)
        {
            leftIndent = (Screen.width / 2 - inputChoiceWindowWidth / 2);
            topIndent = (Screen.height / 2 - inputChoiceWindowHeight / 2);
            inputChoiceWindowRect = new Rect(leftIndent, topIndent, inputChoiceWindowWidth,
                                               inputChoiceWindowHeight);

            inputChoiceWindowRect = GUILayout.Window(0, inputChoiceWindowRect, inputChoiceWindow,
                                                     "Choix du controleur");
        }
        
        if (launched == true && isDead == true)
        {
            leftIndent = (Screen.width / 2 - deadWindowWidth / 2);
            topIndent = (Screen.height / 2 - deadWindowHeight / 2);
            deadWindowRect = new Rect(leftIndent, topIndent, deadWindowWidth,
                                               deadWindowHeight);

            deadWindowRect = GUILayout.Window(0, deadWindowRect, deadWindow,
                                                     "Perdu!");
        }
		if (onPause == true && launched == true)
		{
			leftIndent = (Screen.width / 2 - deadWindowWidth / 2);
			topIndent = (Screen.height / 2 - deadWindowHeight / 2);
			deadWindowRect = new Rect(leftIndent, topIndent, deadWindowWidth,
			                          deadWindowHeight);
			
			deadWindowRect = GUILayout.Window(0, deadWindowRect, pauseWindow,
			                                  "Pause!");
		}

    }

    //Méthode appelée lorsque le client se connecte

    public void connectionUP()
    {
        connected = true;
    }

    public bool withAndroid()
    {
        return iWantToPlayWithAndroid;
    }

     void OnApplicationQuit()
    {	
		if (iWantToPlayWithAndroid) 
		{
			server.GetComponent<ServerHandler> ().Quit ();
		}
    }

}