using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class Sustitute : MonoBehaviour {



	public GameObject manager;
    public Canvas againstTheClock;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindWithTag("manager");
    }
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision other){
		switch(manager.GetComponent<GameManager>().difficulty){
			case "medium": //Modo de juego medio, puedes equivocarte
                if (other.gameObject.tag == "bone")
                {
                    print(other.gameObject.name);
                    if (this.gameObject.transform.parent.GetComponent<Info>().id == other.gameObject.GetComponent<Info>().id && !this.gameObject.transform.parent.GetComponent<Info>().isLocked)//hueso es correcto
                    {
                        if (this.gameObject.transform.parent.GetChild(0).gameObject.activeSelf)//base a correcto
                        {
                            this.gameObject.transform.parent.transform.GetComponent<Info>().placed = true;

                            this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
                            this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
                            manager.gameObject.GetComponent<GameManager>().insertBone(this.gameObject);
                            againstTheClock.gameObject.GetComponent<AgainstTheClock>().changeNumberBonesText();

                            Destroy(other.gameObject);
                        }
                        if (this.gameObject.transform.parent.GetChild(3).gameObject.activeSelf)//error a correcto
                        {
                            this.gameObject.transform.parent.transform.GetComponent<Info>().placed = true;

                            this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
                            this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);

                            againstTheClock.gameObject.GetComponent<AgainstTheClock>().changeNumberBonesText();

                            Destroy(other.gameObject);
                        }
                    }
                    else if (this.gameObject.transform.parent.GetComponent<Info>().id != other.gameObject.GetComponent<Info>().id && !this.gameObject.transform.parent.GetComponent<Info>().isLocked && this.gameObject.transform.parent.GetChild(3).gameObject.activeSelf)
                    {//error a error
                        this.gameObject.transform.parent.GetChild(3).gameObject.transform.localScale = other.gameObject.transform.lossyScale;

                        this.gameObject.transform.parent.GetChild(3).GetComponent<MeshFilter>().mesh = other.gameObject.GetComponent<MeshFilter>().mesh;

                        Destroy(other.gameObject);

                    }
                    else if (this.gameObject.transform.parent.GetComponent<Info>().id != other.gameObject.GetComponent<Info>().id && !this.gameObject.transform.parent.GetComponent<Info>().isLocked && this.gameObject.transform.parent.GetChild(1).gameObject.activeSelf)
                    {//correcto a error
                        this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
                        this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(true);
                        manager.gameObject.GetComponent<GameManager>().insertBone(this.gameObject);
                        againstTheClock.gameObject.GetComponent<AgainstTheClock>().changeNumberBonesText();

                        this.gameObject.transform.parent.GetChild(3).gameObject.transform.localScale = other.gameObject.transform.lossyScale;

                        this.gameObject.transform.parent.GetChild(3).GetComponent<MeshFilter>().mesh = other.gameObject.GetComponent<MeshFilter>().mesh;

                        Destroy(other.gameObject);
                    }
                    else//base a error
                    {
                        this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
                        this.gameObject.transform.parent.GetChild(3).gameObject.SetActive(true);
                        manager.gameObject.GetComponent<GameManager>().insertBone(this.gameObject);
                        againstTheClock.gameObject.GetComponent<AgainstTheClock>().changeNumberBonesText();

                        this.gameObject.transform.parent.GetChild(3).gameObject.transform.localScale = other.gameObject.transform.lossyScale;

                        this.gameObject.transform.parent.GetChild(3).GetComponent<MeshFilter>().mesh = other.gameObject.GetComponent<MeshFilter>().mesh;

                        Destroy(other.gameObject);
                    }
                }
                break;
			case "easy": //Modo de juego facil, si no toca ahi, no se pone
                print("tocandoen easy calabera");
                print(this);
				if(other.gameObject.tag == "bone"){

					if(this.gameObject.transform.parent.GetComponent<Info>().id == other.gameObject.GetComponent<Info>().id && !this.gameObject.transform.parent.GetComponent<Info>().isLocked)
                    {

                        this.gameObject.transform.parent.GetComponent<Info>().placed = true;                                              

						print("derecho");
                                                
                        this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
                        this.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
                        manager.gameObject.GetComponent<GameManager>().insertBone(this.gameObject);
                        againstTheClock.gameObject.GetComponent<AgainstTheClock>().changeNumberBonesText();

                        Destroy(other.gameObject);
                    }
				}
				break;
		}
    }

    public void touchBone()//Si un hueso es tocado, aparece una UI
    {
        if(manager.gameObject.transform.GetComponent<GameManager>().difficulty == "medium" && !this.gameObject.transform.parent.GetChild(0).gameObject.activeSelf)
        {
            if (!manager.gameObject.transform.GetComponent<GameManager>().isActive)
            {
                manager.gameObject.transform.GetComponent<GameManager>().isActive = true;
                manager.gameObject.transform.GetComponent<GameManager>().activeUI = this.gameObject.transform.parent.GetChild(2).gameObject;

                if (!this.gameObject.transform.parent.GetComponent<Info>().isLocked && manager.gameObject.transform.GetComponent<GameManager>().state == "normal")
                {
                    print("tocando con las manos n");
                    this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(true); //set
                    this.gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.SetActive(true); //set
                    this.gameObject.transform.parent.GetChild(2).GetChild(1).gameObject.SetActive(true); //expel
                    this.gameObject.transform.parent.GetChild(2).GetChild(3).gameObject.SetActive(true); //set

                    StartCoroutine("dissapearButtons");
                }
                else if (this.gameObject.transform.parent.GetComponent<Info>().isLocked && manager.gameObject.transform.GetComponent<GameManager>().state == "unlocking")
                {
                    print("tocando con las manos u");
                    this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
                    this.gameObject.transform.parent.GetChild(2).GetChild(2).gameObject.SetActive(true); //unlock
                    this.gameObject.transform.parent.GetChild(2).GetChild(3).gameObject.SetActive(true); //set

                    StartCoroutine("dissapearButtons");
                }
            }
            else
            {
                manager.gameObject.transform.GetComponent<GameManager>().activeUI.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                manager.gameObject.transform.GetComponent<GameManager>().activeUI.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                manager.gameObject.transform.GetComponent<GameManager>().activeUI.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                manager.gameObject.transform.GetComponent<GameManager>().activeUI.gameObject.transform.GetChild(3).gameObject.SetActive(false);

                manager.gameObject.transform.GetComponent<GameManager>().activeUI = this.gameObject.transform.parent.GetChild(2).gameObject;

                if (!this.gameObject.transform.parent.GetComponent<Info>().isLocked && manager.gameObject.transform.GetComponent<GameManager>().state == "normal")
                {
                    print("tocando con las manos n");
                    this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(true); 
                    this.gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.SetActive(true); 
                    this.gameObject.transform.parent.GetChild(2).GetChild(1).gameObject.SetActive(true); 
                    this.gameObject.transform.parent.GetChild(2).GetChild(3).gameObject.SetActive(true); 

                    StartCoroutine("dissapearButtons");
                }
                else if (this.gameObject.transform.parent.GetComponent<Info>().isLocked && manager.gameObject.transform.GetComponent<GameManager>().state == "unlocking")
                {
                    print("tocando con las manos u");
                    this.gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
                    this.gameObject.transform.parent.GetChild(2).GetChild(2).gameObject.SetActive(true); 
                    this.gameObject.transform.parent.GetChild(2).GetChild(3).gameObject.SetActive(true); 

                    StartCoroutine("dissapearButtons");
                }
            }
        }
    }

    IEnumerator dissapearButtons()//Hace los botones de los huesos desaparecer tras un tiempo
    {
        yield return new WaitForSeconds(8);

        this.gameObject.transform.parent.GetChild(2).GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(2).GetChild(1).gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(2).GetChild(2).gameObject.SetActive(false); 
        this.gameObject.transform.parent.GetChild(2).GetChild(3).gameObject.SetActive(false); 

        yield return null;
    }
}
