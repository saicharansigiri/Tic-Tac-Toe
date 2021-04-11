using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    public int whosTurn;
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playIcons;
    public Button[] tictactoeSpaces;
    public int[] markedSpaces;
    public Text WinnerText;
    public GameObject[] winningLines;
    public GameObject WinnerPannel;
    public int xPlayersScore;
    public int oPlayersScore;
    public Text xPlaterScoreText;
    public Text oPlayerScoreText;
    public Button xPlayerButton;
    public Button oPlayerButton;
    public GameObject TieImage;


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup() 
    {

        whosTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for (int i = 0; i < tictactoeSpaces.Length; i++) 
        {
            tictactoeSpaces[i].interactable = true;
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < tictactoeSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int whichnumber) 
    {
        xPlayerButton.interactable = false;
        oPlayerButton.interactable = false;
        tictactoeSpaces[whichnumber].image.sprite = playIcons[whosTurn];
        tictactoeSpaces[whichnumber].interactable = false;

        markedSpaces[whichnumber] = whosTurn+1;
        turnCount++;

        if (turnCount >= 4) {
           bool iswinner =  Winnercheck();
            if (turnCount == 9 && iswinner==false) {
                TieFunction();
            }
        }
    
        if (whosTurn == 0)
        {
            whosTurn = 1;

            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else {
            whosTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    
    }

    bool Winnercheck() 
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];
        var Solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for (int i = 0; i < Solutions.Length; i++)
        {
            if (Solutions[i] == 3 *(whosTurn + 1))
            {

                winnerDisplay(i);
                return true;
            }
            
        }
        return false;
    }


    void winnerDisplay(int index ) 
    {
        WinnerPannel.gameObject.SetActive(true);
        if (whosTurn == 0) {
           
            WinnerText.text = "Player X Wins!";
            xPlayersScore++;
            xPlaterScoreText.text = xPlayersScore.ToString();
        }
        else if(whosTurn==1){
            
            WinnerText.text = "Player O Wins!";
            oPlayersScore++;
            oPlayerScoreText.text = oPlayersScore.ToString();
        }
        winningLines[index].SetActive(true);
        
        
    }

    public void Rematch() 
    {
        TieImage.SetActive(false);
        xPlayerButton.interactable = true;
        oPlayerButton.interactable = true;
        GameSetup();
        for (int i = 0; i < winningLines.Length; i++)
        {
            winningLines[i].SetActive(false);
        }
        WinnerPannel.SetActive(false);
    }

    public void ReStart() 
    {
        TieImage.SetActive(false);
        Rematch();
        xPlayersScore = 0;
        oPlayersScore = 0;
        xPlaterScoreText.text = "0";
        oPlayerScoreText.text = "0";

    }

    public void SwitchPlayer(int whichplayer) 
    {
        if (whichplayer == 0)
        {
            whosTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);

        }
        else if (whichplayer == 1) {
            whosTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }


    }

    void TieFunction() {
        TieImage.SetActive(true);

    }
}
