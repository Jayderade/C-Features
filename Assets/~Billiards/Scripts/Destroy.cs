﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{
    public class Destroy : MonoBehaviour
    {

        public Text countText;

        private int count;

        // Use this for initialization
        void Start()
        {
            count = 0;
            SetCountText();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                
                count = count + 1;
                SetCountText();

            }
        }

        void SetCountText()
        {
            countText.text = "Score:" + count.ToString();
        }
    }
}
