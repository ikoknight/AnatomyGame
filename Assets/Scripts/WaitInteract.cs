using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitInteract : MonoBehaviour {

    public HandButtons script;

	// Use this for initialization
	void Start () {
        Invoke("activateScript", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activateScript()
    {
        script.enabled = true;

    }
}
