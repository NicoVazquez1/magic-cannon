using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int score = 0;
    GameObject[] boxes;
    Spawner spawner;
  
    void Start()
    {
    }

    void Update()
    {
        boxes = GameObject.FindGameObjectsWithTag("box");
        spawner = FindObjectOfType<Spawner>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box")
        {
            Destroy(collision.gameObject, 2);
            
            
            score++;
        }
    }
}
