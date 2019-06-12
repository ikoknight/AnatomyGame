using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class Sustitute : MonoBehaviour {



	public GameObject manager;

	Sustitute sustitute;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindWithTag("manager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

//DESAPARECER TRAS 5 SEGUNDOS
//DESAPARECER SI SE TOCA OTRO OBJETO
//HACER SPAWN A UNA DISTANCIA QUE NO TAPE OTROS HUESOS
//HACER HIDE Y UNHIDE DE BOTONES (ACTIVATE)
//VARIABLE ID


	void OnCollisionEnter(Collision other){
		switch(manager.GetComponent<GameManager>().difficulty){
			case "medium": //Modo de juego dificil, puedes equivocarte

				break;
			case "easy": //Modo de juego facil, si no toca ahi, se expulsa
                print("tocandoen easy calabera");
                print(this);
				if(other.gameObject.tag == "bone"){

					if(this.gameObject.GetComponent<Info>().id == other.gameObject.GetComponent<Info>().id && !this.gameObject.GetComponent<Info>().isSet)
                    {

                        this.gameObject.transform.GetComponent<Info>().placed = true;

                        //this.gameObject.GetComponent<Info>().isSet = true;
                                              

						print("derecho");
                                                
                        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

                        Destroy(other.gameObject);
                    }
					else{
						//escupir hueso
					}
				}
				break;
		}


    }

    public void touchBone()
    {
        print("tocando con las manos");
        if (!this.gameObject.transform.GetComponent<Info>().isSet && this.gameObject.transform.GetComponent<Info>().placed)
        {
            this.gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(true); //set
            this.gameObject.transform.GetChild(2).GetChild(2).gameObject.SetActive(true); //expel

            StartCoroutine("dissapearButtons");
        }
    }

    IEnumerator dissapearButtons()
    {

        yield return new WaitForSeconds(5);

        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

    }
}
