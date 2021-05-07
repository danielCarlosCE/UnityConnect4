using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour, GameBoardDelegate
{
    public GameObject Sphere;
    
    private int columns = 7;
    private int rows = 6;
    
    private GameBoard gameboard;
    private List<GameObject> spheres = new List<GameObject>();
    private bool isIdle = true;
    private bool isPlay1 = true;
    private int[][] boardPlays;

    void Start()
    {           
        gameboard = GameObject.Find("GameBoard").GetComponent<GameBoard>();
        gameboard.myDelegate = this;

        boardPlays = new int[columns][];
        for (int i = 0; i < columns; i++) {
            boardPlays[i] = new int[rows];
        }

        AddNewSphere();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") == false)
            return;

        if (!isIdle) { return; }
        
        var currentSphere = spheres[spheres.Count - 1];
        Ball ball = currentSphere.GetComponent<Ball>();
        int column = ball.columnSelected;
        int row = gameboard.availableRow(column);
        
        if (row == -1) {
            return;
        }
        
        boardPlays[column][row] = isPlay1 ? 1 : 2;
        isPlay1 = !isPlay1;
        isIdle = false;
        ball.isActive = false;
        //drop ball with gravity
        currentSphere.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void OnIdle() {
        BoardGameVerifier verifier = new BoardGameVerifier(boardPlays);
        if (verifier.isGameOver()) {
            int playerLastMove = isPlay1 ? 2 : 1;
            SessionGameState.playerWon = playerLastMove;
            SceneManager.LoadScene("WinScene");
            return;
        }
        isIdle = true;
        AddNewSphere();    
    }

    private void AddNewSphere() {
        GameObject nextSphere = Instantiate(Sphere, new Vector3(-3f, 4f, 0.5f), Quaternion.identity);
        var renderer = nextSphere.GetComponent<Renderer>();

        renderer.material.SetColor("_Color", isPlay1 ? Color.red : Color.blue);

        spheres.Add(nextSphere);
    }
    
}
