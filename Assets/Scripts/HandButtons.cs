using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandButtons : MonoBehaviour {

    public GameObject objectToSpawn;
    public GameObject spawnBonePoint;


	// Use this for initialization
	void Start () {
        this.gameObject.layer = 9;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TouchButtonHand()
    {
        print("yo soy el objeto" + this.gameObject);

        GameObject bone = Instantiate(objectToSpawn, spawnBonePoint.transform.position, Quaternion.identity);

        
    }
}
