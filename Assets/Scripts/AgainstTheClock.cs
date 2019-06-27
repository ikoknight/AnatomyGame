using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgainstTheClock : MonoBehaviour {

    public Text counterText;
    public Text numberBonesText;

    public GameObject buttonSolo;

    public GameObject manager;

    public int numberBones;
    public int numberBonesCorrect;

    public string timeText;

    public float timer;

	// Use this for initialization
	void Start () {
        timer = 10.0f;

        numberBonesCorrect = manager.gameObject.GetComponent<GameManager>().calculateBonesCorrect();
    }

    // Update is called once per frame
    void Update () {

    }

    public void changeNumberBonesText()//Cambia el texto del contador de huesos
    {
        numberBonesCorrect = manager.gameObject.GetComponent<GameManager>().calculateBonesCorrect();
        numberBones = manager.gameObject.GetComponent<GameManager>().calculateBones();

        if (manager.gameObject.transform.GetComponent<GameManager>().difficulty == "easy")
        {
            if (numberBones >= 25)
            {
                numberBonesText.text = "You win!";
                manager.gameObject.GetComponent<GameManager>().restartAll();
            }
            else
            {
                numberBonesText.text = "Bones: " + numberBones + " / 25";
            }
        }

        if (manager.gameObject.transform.GetComponent<GameManager>().difficulty == "medium")
        {
            if (numberBonesCorrect >= 25)
            {
                numberBonesText.text = "You win!";
                manager.gameObject.GetComponent<GameManager>().restartAll();
            }
            else
            {
                numberBonesText.text = "Bones: "+ numberBones + " / 25";
            }
        }
    }

    IEnumerator startCounter()//Empieza el contador cuando se entra en partida y cambia el texto
    {
        while(timer > 0.5f)
        {
            if(numberBonesCorrect == 25)
            {
                numberBonesText.text = "You Win!";
                yield return new WaitForSeconds(3);

                manager.gameObject.GetComponent<GameManager>().restartAll();
                yield return null;
            }

            else if (numberBonesCorrect != 25)
            {
                timer -= Time.deltaTime;

                string minutes = Mathf.Floor(timer / 60).ToString("00");
                string seconds = (timer % 60).ToString("00");

                timeText = string.Format("{0}:{1}", minutes, seconds);

                counterText.text = timeText;
                print(timeText);

                yield return null;
            }
        }
        numberBonesText.text = "You lose!";

        yield return new WaitForSeconds(3);

        manager.gameObject.GetComponent<GameManager>().restartAll();

        yield return null;
    }
}
