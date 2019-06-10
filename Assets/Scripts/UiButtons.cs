using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtons : MonoBehaviour {

    public string id;
    public GameObject gameManager;



        // Use this for initialization
    void Start () {
        this.gameObject.layer = 9;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TouchButtonSoloCoop()
    {
        print("tocando solo");
        //GameObject bone = Instantiate(objectToSpawn, spawnPosition);
        gameManager.gameObject.transform.GetComponent<GameManager>().players = id;
        this.gameObject.transform.parent.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;

        this.gameObject.transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;

        StartCoroutine("dissapearButtonsSoloCoop");
        
    }

    IEnumerator dissapearButtonsSoloCoop()
    {

        yield return new WaitForSeconds(3);

        this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(true);

        this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);

    }

    public void TouchButtonFreeTime()
    {
        //GameObject bone = Instantiate(objectToSpawn, spawnPosition);
        gameManager.gameObject.transform.GetComponent<GameManager>().gamemode = id;
        this.gameObject.transform.parent.GetChild(2).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(3).gameObject.GetComponent<Renderer>().enabled = false;

        this.gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;

        StartCoroutine("dissapearButtonsFreeTime");

    }

    IEnumerator dissapearButtonsFreeTime()
    {

        yield return new WaitForSeconds(3);

        this.gameObject.transform.parent.GetChild(4).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(5).gameObject.SetActive(true);

        this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);

    }

    public void TouchButtonEasyMedium()
    {
        //GameObject bone = Instantiate(objectToSpawn, spawnPosition);
        gameManager.gameObject.transform.GetComponent<GameManager>().difficulty = id;
        this.gameObject.transform.parent.GetChild(4).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(5).gameObject.SetActive(false);
    }




}
