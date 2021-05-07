using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameBoardDelegate {
    void OnIdle();
}

public class GameBoard : MonoBehaviour, BoxBottomDelegate
{

    public GameBoardDelegate myDelegate;

    public int availableRow(int columnIndex) {
        for (int r=5; r >= 0; r--) {
            GameObject obj = GameObject.Find("Column"+columnIndex+"/row"+r+"/bottom");
            if (obj.GetComponent<BoxBottom>().filled == false) {
                return r;
            }
        }
        return -1;
    }

    void Start()
    {
        for (int c = 0; c < 7; c++) 
        {
            for (int r = 0; r < 6; r++) {
                var bottom = GameObject.Find("Column"+c+"/row"+r+"/bottom").GetComponent<BoxBottom>();
                bottom.column = c;
                bottom.row = r;
                bottom.myDelegate = this;
            }
        }
    }

    public void OnBoxBottomCollide(BoxBottom bottom) {
        myDelegate?.OnIdle();
        var c = bottom.column;
        var r = bottom.row;
        if (r < 1) { return; }

        GameObject obj = GameObject.Find("Column"+c+"/row"+ (r-1) +"/bottom");
        obj.SetActive(true);
    }
}
