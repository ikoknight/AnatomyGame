using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public string players; //Elecciones del menu
    public string gamemode;
    public string difficulty;

    public List<GameObject> bones; //Lista de huesos

    public int numberBones;
    public int numberBonesCorrect;
    public int helpCounter;

    public GameObject againstTheClock;
    public GameObject skeleton;

    public GameObject menu;

    public Color redColor = Color.red;
    public Color blueColor = Color.blue;
    public Color whiteColor = Color.white;

    public GameObject leap;

    public string state; //Estado de lock/unlock

    public GameObject spawnLeapPoint;

    public GameObject rightLeap;
    public GameObject leftLeap;

    public GameObject rightButtons;
    public GameObject leftButtons;

    public GameObject activeUI;
    public bool isActive; 

    public GameObject unlockButton;
    public GameObject helpButton;

    public Text helpCounterText;

    void Start () {
        bones = new List<GameObject>();
        numberBones = 0;
        state = "normal";
        leap.transform.position = spawnLeapPoint.transform.position;
    }
	
	void Update () {//Si las manos no se están renderizando, ocultamos la UI también
        if (!menu.gameObject.transform.GetChild(6).gameObject.activeSelf)
        {
            if (!leftLeap.gameObject.activeSelf)
            {
                leftButtons.gameObject.SetActive(false);
            }
            else
            {
                leftButtons.gameObject.SetActive(true);
            }
            if (!rightLeap.gameObject.activeSelf)
            {
                rightButtons.gameObject.SetActive(false);
            }
            else
            {
                rightButtons.gameObject.SetActive(true);
            }
        }
        else
        {
            leftButtons.gameObject.SetActive(false);
            rightButtons.gameObject.SetActive(false);
        }
    }

    public void insertBone(GameObject bone)//Insertamos los huesos en una lista
    {
        bones.Add(bone);
        againstTheClock.gameObject.GetComponent<AgainstTheClock>().changeNumberBonesText();
    }

    public void deleteBone(GameObject bone)
    {
        bones.Remove(bone);
    }

    public void unlockBones()//Cambia el estado y color de los huesos
    {
        print("paso a rojo");
        if (state == "normal")
        {
            foreach (GameObject bone in bones)
            {
                if (bone.gameObject.transform.parent.GetComponent<Info>().isLocked == true)
                {
                    StartCoroutine("changeColorsRed", bone);
                }

            }
            state = "unlocking";
        }
        else
        {
            unlockBonesBack();
            state = "normal";
        }
    }

    public void unlockBonesBack()//Pone los huesos rojos en blanco
    {
        print("vuelvo a blanco");
        foreach (GameObject bone in bones)
        {
            changeColorsWhite(bone);
        }
    }

    public void helpBones()//Recorre el vector de huesos y pone azules los que estén bien puestos
    {
        helpCounter = helpCounter + 1;
        helpCounterText.text = "Used help: " + helpCounter + " times";
        foreach (GameObject bone in bones)
        {
            if (bone.gameObject.transform.parent.GetComponent<Info>().placed == true)
            {
                StartCoroutine("changeColorsBlue", bone);
            }
        }
    }

    IEnumerator changeColorsRed(GameObject bone)//Pone el hueso en rojo cuando estás en unlock y el hueso está lock
    {
        bone.gameObject.transform.parent.GetChild(3).GetComponent<Renderer>().material.color = redColor;
        bone.gameObject.transform.parent.GetChild(1).GetComponent<Renderer>().material.color = redColor;

        yield return new WaitForSeconds(10);

        changeColorsWhite(bone);

        yield return null;
    }
    
    IEnumerator changeColorsBlue(GameObject bone)//Pone el hueso en azul cuando entras en ayuda
    {
        bone.gameObject.transform.parent.GetChild(1).GetComponent<Renderer>().material.color = blueColor;

        yield return new WaitForSeconds(10);

        changeColorsWhite(bone);

        yield return null;
    }

    public void changeColorsWhite(GameObject bone)//Regresa los huesos a color blanco
    {
        bone.gameObject.transform.parent.GetChild(1).GetComponent<Renderer>().material.color = whiteColor;
        bone.gameObject.transform.parent.GetChild(3).GetComponent<Renderer>().material.color = whiteColor;
    }

    public void restartAll() //Reinicia los valores de modos de juego y reactivamos el menu
    {
        players = "";
        gamemode = "";
        difficulty = "";

        helpCounter = 0;

        menu.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        menu.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        cleanList();

        menu.gameObject.transform.GetChild(0).gameObject.GetComponent<UiButtons>().callMenu();
    }

    public void cleanList() //Limpia el array de huesos cuando acaba la partida o volvemos al menu
    {
        foreach (GameObject bone in bones)
        {
            bone.gameObject.transform.parent.GetComponent<Info>().placed = false;
            bone.gameObject.transform.parent.GetComponent<Info>().isLocked = false;
            bone.gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);
            bone.gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
            bone.gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
        }
        bones.Clear();
    }

    public int calculateBones()
    {
        numberBones = bones.Count;

        return numberBones;
    }

    public int calculateBonesCorrect()//Recorre el vector de huesos y pone azules los que estén bien puestos
    {
        numberBonesCorrect = 0;
        foreach (GameObject bone in bones)
        {
            if (bone.gameObject.transform.parent.GetComponent<Info>().placed == true)
            {
                numberBonesCorrect = numberBonesCorrect + 1;
            }
        }
        return numberBonesCorrect;
    }
}
