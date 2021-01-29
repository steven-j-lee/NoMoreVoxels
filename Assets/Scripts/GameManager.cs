using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public variables for mesh to be instanced
    public int count = 1000;
    public GameObject island;
    
    //variables for the player
    private bool isPlaying;
    [SerializeField] private ShipController shipController;
    [SerializeField] private PlayerShoot playerShoot;
    [SerializeField] private GameObject ship;
    
    
    //variabels for the menu
    [SerializeField] private GameObject logos;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject UIScore;

    private TextMeshProUGUI text;

    void Awake()
    {
        isPlaying = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = UIScore.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Game is quitting...");
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.G) && !isPlaying)
        {
            isPlaying = true;
            shipController.enabled = true;
            playerShoot.enabled = true;
            logos.SetActive(false);
        }

        //check if the game is over
        if (shipController.isGameOver)
        {
            //Debug.Log("Game Over");
            gameOver.SetActive(true);
            gameOver.transform.position = ship.transform.position;

        }
        
        //update score
        //Debug.Log(shipController.playerScore);
        text.SetText("Player Score: " + shipController.playerScore);

    }



}
