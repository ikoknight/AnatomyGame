using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneButtons : MonoBehaviour {

    public string id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TouchButtonBone()
    {
        print("tocando");
        switch (id)
        {
            case "setButton":
                this.transform.parent.parent.gameObject.GetComponent<Info>().isSet = true;
                this.transform.parent.gameObject.SetActive(false);
                //animation hide buttons

                break;
            case "expelButton":

                print("expulsando");
                this.transform.parent.parent.GetChild(0).gameObject.SetActive(true); //base
                this.transform.parent.parent.GetChild(1).gameObject.SetActive(false); //bone
                this.transform.parent.parent.GetChild(2).gameObject.SetActive(false); //canvas

                this.transform.parent.parent.GetComponent<Info>().placed = false;

                //animation hide buttons
                //animation destroy
                break;
            case "unsetButton":
                this.transform.parent.parent.GetChild(0).GetComponent<Info>().isSet = false;
                //other.color = azul
                //other.gameObject.transform.GetChild(0).disable//Hidebutton

                break;
        }
    }




}
