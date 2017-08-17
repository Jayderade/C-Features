using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour {

    public float gravity = -9.81f;

    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid.velocity += Vector3.back * gravity;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity -= Vector3.back * gravity;
    }

    void LateUpdate()
    {
        rigid.velocity += Vector3.back * gravity;
    }
}
