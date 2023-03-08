using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class time : MonoBehaviour
{
    public GameObject clock;
    private float timer;

    public float timeRemaining = 120;

    // Start is called before the first frame update
    void Start()
    {
        //timer = clock.GetComponent<timer>().timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time over");
        }
    }
}
