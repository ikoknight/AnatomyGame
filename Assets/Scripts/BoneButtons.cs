using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneButtons : MonoBehaviour {

    public string id;
    public GameObject manager;

	void Start () {
	}
	
	void Update () {
	}

    public void TouchButtonBone()//Actúa dependiendo del botón tocado
    {
        print("tocando");
        switch (id)
        {
            case "lockButton":
                this.transform.parent.parent.gameObject.GetComponent<Info>().isLocked = true;
                this.transform.parent.GetChild(0).gameObject.SetActive(false);
                this.transform.parent.GetChild(1).gameObject.SetActive(false);

                this.transform.parent.gameObject.SetActive(false);

                break;
            case "expulseButton":

                this.transform.parent.parent.GetChild(0).gameObject.SetActive(true); //base
                this.transform.parent.parent.GetChild(1).gameObject.SetActive(false); //bone
                this.transform.parent.parent.GetChild(2).gameObject.SetActive(false); //canvas
                this.transform.parent.parent.GetChild(3).gameObject.SetActive(false); //error

                this.transform.parent.parent.GetComponent<Info>().placed = false;
                manager.gameObject.GetComponent<GameManager>().deleteBone(this.gameObject);

                this.transform.parent.GetChild(0).gameObject.SetActive(false);
                this.transform.parent.GetChild(1).gameObject.SetActive(false);

                this.transform.parent.gameObject.SetActive(false);

                break;
            case "unlockButton":
                this.transform.parent.parent.GetComponent<Info>().isLocked = false;
                manager.gameObject.GetComponent<GameManager>().changeColorsWhite(this.gameObject.transform.parent.parent.GetChild(1).gameObject);
                manager.gameObject.GetComponent<GameManager>().changeColorsWhite(this.gameObject.transform.parent.parent.GetChild(3).gameObject);

                this.transform.parent.GetChild(2).gameObject.SetActive(false);
                this.transform.parent.gameObject.SetActive(false);

                break;
        }
    }
}
