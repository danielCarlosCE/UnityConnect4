using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BoxBottomDelegate {
    void OnBoxBottomCollide(BoxBottom bottom);
}

public class BoxBottom : MonoBehaviour
{
    public BoxBottomDelegate myDelegate;
    public int column = -1;
    public int row = -1;
    public bool filled = false;

    void OnCollisionEnter(Collision collision)
    {
        myDelegate?.OnBoxBottomCollide(this);
        filled = true;
    }

}