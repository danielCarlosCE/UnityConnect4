using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isActive = true;
    public int columnSelected {
        get { return (int) (this.transform.position.x + 3f); }
    }

    void Update()
    {
        Vector3 position = this.transform.position;

        if (Input.GetKeyDown("left")) {
            if (!isActive) 
                return;
            position.x--;
            if (position.x < -3) {
                return;
            }
            this.transform.position = position;
        }
        if (Input.GetKeyDown("right")) {
            if (!isActive) 
                return;
            position.x++;
            if (position.x > 3) {
                return;
            }
            this.transform.position = position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
