using UnityEngine;

public class BoardGameVerifier: MonoBehaviour
{
    private int[][] boardPlays;
    public int emptySpace = 0;
    private int playsToWin = 4;
    
    public BoardGameVerifier(int[][] boardPlays){
        this.boardPlays = boardPlays;
    }

    private int columns { 
        get { return boardPlays.Length; } 
    }
    private int rows { 
        get { return boardPlays[0].Length; }         
    }

    public bool isGameOver() {
        for (int c = 0; c < columns ; c++) 
        {
            for (int r = 0; r < rows; r++) {                
                if (boardPlays[c][r] == emptySpace) {
                    continue;
                }

                bool isWin = checkWinVertical(c, r) 
                        || checkWinHorizontal(c, r)
                        || checkDiagonalRight(c, r)
                        || checkDiagonalLeft(c, r);

                if (isWin) {
                    return true;
                }

            }
        }
        return false;
    }
    
    private bool checkWinHorizontal(int c, int r) { 
        print("check horizontal");
        int nextC = c+1;
        if (!isInBounds(nextC, r))
            return false;
        
        if (boardPlays[nextC][r] != boardPlays[c][r]) {
            return false;
        }       
        var total = 2;
        nextC++;
        while(true) {
            if (!isInBounds(nextC, r) || boardPlays[nextC][r] != boardPlays[c][r]) {
                break;
            } 
            total ++;
            nextC ++;
        }

        return total >= playsToWin;
    }

    private bool checkWinVertical(int c, int r) {
        print("check vertical");
        int nextR = r+1;
        if (!isInBounds(c, nextR))
            return false;

        if (boardPlays[c][nextR] != boardPlays[c][r]) {
            return false;
        }
       
        var total = 2;
        nextR ++;

        while(true) {
            if (!isInBounds(c, nextR) || boardPlays[c][nextR] != boardPlays[c][r])
                break;
            
            total ++;
            nextR ++;             
        }
        
        return total >= playsToWin;
    }

    private bool checkDiagonalRight(int c, int r) {
        print("check diagonal");
        int nextC = c-1;
        int nextR = r+1;
        
        if (!isInBounds(nextC, nextR))
            return false;

        if (boardPlays[nextC][nextR] != boardPlays[c][r]) { 
            return false; 
        }

        var total = 2;
        nextC--;
        nextR++;        
        while(true) {
            if (!isInBounds(nextC, nextR) || boardPlays[nextC][nextR] != boardPlays[c][r]) {
                break;
            }

            total ++;
            nextC --;
            nextR ++;
        }

        return total >= playsToWin;
    }

    private bool checkDiagonalLeft(int c, int r) {
        print("check diagonal");
        int nextC = c+1;
        int nextR = r+1;

        if (!isInBounds(nextC, nextR))
            return false;

        if (boardPlays[nextC][nextR] != boardPlays[c][r]) { 
            return false; 
        }

        var total = 2;
        nextC++;
        nextR++;

        while(true) {
            if (!isInBounds(nextC, nextR) || boardPlays[nextC][nextR] != boardPlays[c][r]) {
                break;
            }

            total ++;
            nextC ++;
            nextR ++;
        }

        return total >= playsToWin;
    }

    private bool isInBounds(int c, int r) {
        return c >= 0 && c < columns && r >= 0 && r < rows;
    }
}
