using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtons : MonoBehaviour {

    public string id;
    public GameObject gameManager;
    public GameObject againstTheClock;

    public GameObject tutorial;

    public GameObject skeleton;

    void Start () {
        this.gameObject.layer = 9;
    }

    void Update()
    {
    }
		
    public void callMenu() {//Llama de nuevo al menu
        againstTheClock.gameObject.GetComponent<AgainstTheClock>().timer = 10.0f;
        this.gameObject.transform.parent.GetChild(6).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(1).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(1).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameManager.gameObject.transform.GetComponent<GameManager>().cleanList();
    }

    public void TouchButtonSoloCoop()//Es llamada al tocar los botones solo y cooperative
    {
        gameManager.gameObject.transform.GetComponent<GameManager>().players = id;
        this.gameObject.transform.parent.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;

        this.gameObject.transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(1).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;

        StartCoroutine("dissapearButtonsSoloCoop"); 
    }

    IEnumerator dissapearButtonsSoloCoop()//Es llamada para hacer desaparecer los botones solo y cooperative
    {
        yield return new WaitForSeconds(2);

        this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(2).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(3).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.parent.GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;

        this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
    }

    public void TouchButtonFreeTime()//Es llamada al tocar los botones free y againstTheClock
    {
        gameManager.gameObject.transform.GetComponent<GameManager>().gamemode = id;
        this.gameObject.transform.parent.GetChild(2).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;

        this.gameObject.transform.parent.GetChild(3).gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.parent.GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;

        this.gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;

        this.gameObject.transform.parent.GetChild(3).GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;

        StartCoroutine("dissapearButtonsFreeTime");
    }

    IEnumerator dissapearButtonsFreeTime()//Es llamada para hacer desaparecer los botones free y againstTheClock
    {
        yield return new WaitForSeconds(2);

        this.gameObject.transform.parent.GetChild(4).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(4).GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(5).gameObject.SetActive(true);
        this.gameObject.transform.parent.GetChild(5).GetChild(0).GetChild(0).gameObject.SetActive(true);

        this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
    }

    public void TouchButtonEasyMedium()//Es llamada al tocar los botones easy o medium
    {
        //GameObject bone = Instantiate(objectToSpawn, spawnPosition);
        gameManager.gameObject.transform.GetComponent<GameManager>().difficulty = id;
        this.gameObject.transform.parent.GetChild(4).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(5).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(6).gameObject.SetActive(false);

        if (gameManager.gameObject.transform.GetComponent<GameManager>().gamemode == "time")
        {
            print("entra en modo time");
            againstTheClock.gameObject.transform.GetComponent<AgainstTheClock>().StartCoroutine("startCounter");
            againstTheClock.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        againstTheClock.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        againstTheClock.gameObject.transform.GetComponent<AgainstTheClock>().changeNumberBonesText();

        gameManager.gameObject.transform.GetComponent<GameManager>().skeleton.SetActive(true);
        if(gameManager.gameObject.transform.GetComponent<GameManager>().difficulty == "easy")
        {
            gameManager.gameObject.transform.GetComponent<GameManager>().unlockButton.SetActive(false);
            gameManager.gameObject.transform.GetComponent<GameManager>().helpButton.SetActive(false);
            tutorial.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (gameManager.gameObject.transform.GetComponent<GameManager>().difficulty == "medium")
        {
            gameManager.gameObject.transform.GetComponent<GameManager>().unlockButton.SetActive(true);
            gameManager.gameObject.transform.GetComponent<GameManager>().helpButton.SetActive(true);
            tutorial.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void dissapearTuto()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
