using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallMovement : MonoBehaviour
{
    public GameObject barrel;
    public static event Action BallPickedUp = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        BallData data = BallMachine.Balls.BallList[UnityEngine.Random.Range(0, BallMachine.Balls.BallList.Count)];



        if (data.color.Equals("red"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (data.color.Equals("green"))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (data.color.Equals("blue"))
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        GetComponent<Rigidbody>().AddForce((barrel.transform.up - barrel.transform.forward) * data.velocity * 40f);
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("hit Player");
            BallPickedUp();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "Island")
        {
            Debug.Log("hit Ground");
            ScoreManager.Lose();
            Destroy(this.gameObject);
        }
    }
}
