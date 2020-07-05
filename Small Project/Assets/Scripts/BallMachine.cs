using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class BallJSONList
{
    public List<BallData> BallList;
}

[System.Serializable]
public class BallData
{
    public string color;
    public int velocity;
}

public class BallMachine : MonoBehaviour
{
    public static BallJSONList Balls;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;
    public Transform barrelEnd;


    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(@"Assets/ballList.json");
        BallMachine.Balls = JsonUtility.FromJson<BallJSONList>(json);

        InvokeRepeating("SpawnBall", spawnTime, spawnDelay);
    }


    void SpawnBall()
    {
        GameObject BallPrefab = Resources.Load<GameObject>("Sphere");
        Instantiate(BallPrefab, barrelEnd.position, barrelEnd.rotation);

        if(stopSpawning)
        {
            CancelInvoke("SpawnBall");
        }
    }

   

}
