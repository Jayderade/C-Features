using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour {

    public Material[] colour;

    private Renderer rend;

    
    
    
    // Use this for initialization
    void Start () {
        RanMaterials();
        ;
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    void RanMaterials()
    {
        int randomMat = Random.Range(0, colour.Length);
        rend = GetComponent<Renderer>();
        rend.material = colour[randomMat];
        
    }
}
