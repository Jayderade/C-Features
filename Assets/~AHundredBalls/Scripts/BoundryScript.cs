using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoundryScript : MonoBehaviour {

    public Text Text;

    private int count;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            
            count = count + 1;
            SetScore();
        }
    }

	// Use this for initialization
	void Start () {
        count = 0;
        SetScore();
    }
    void SetScore()
    {
        Text.text = "Amount of Balls you Don't Have:" + count.ToString();
    }
    // Update is called once per frame
    void Update () {
        SetScore();
    }
}
