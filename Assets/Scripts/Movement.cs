using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
		var y = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;

		if(Input.GetKey(KeyCode.F)){
			transform.Rotate(0, 10* Time.deltaTime * 30.0f, 0);
		}

        
        transform.Translate(0, 0, z);
		transform.Translate(y,0,0);
		
	}
	
}