using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyScore : MonoBehaviour
{

    public Text Score;

    private int count;

    // Use this for initialization
    void Start()
    {
        count = 0;
        SetScore();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Ball"))
        {
            count = count + 1;
            SetScore();
            
        }

    }

    void SetScore()
    {
        Score.text = "Amount of Balls you Have:" + count.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        SetScore();
    }
}
