using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public string players;
    public string gamemode;
    public string difficulty;
    public GameObject[] bones;

    public GameObject skull;
    public GameObject vertebras;
    public GameObject sternum;
    public GameObject ribs;
    public GameObject pelvis;
    public GameObject rightScapula;
    public GameObject rightHumerus;
    public GameObject rightUlna;
    public GameObject rightRadius;
    public GameObject rightHand;
    public GameObject leftScapula;
    public GameObject leftHumerus;
    public GameObject leftUlna;
    public GameObject leftRadius;
    public GameObject leftHand;
    public GameObject rightFemur;
    public GameObject rightFibula;
    public GameObject rightTibia;
    public GameObject rightPatella;
    public GameObject rightFoot;
    public GameObject leftFemur;
    public GameObject leftFibula;
    public GameObject leftTibia;
    public GameObject leftPatella;
    public GameObject leftFoot;






    // Use this for initialization

    void Start () {
        bones = new GameObject[25];

        bones[0] = skull;
        bones[1] = vertebras;
        bones[2] = sternum;
        bones[3] = ribs;
        bones[4] = pelvis;
        bones[5] = rightScapula;
        bones[6] = rightHumerus;
        bones[7] = rightUlna;
        bones[8] = rightRadius;
        bones[9] = rightHand;
        bones[10] = leftScapula;
        bones[11] = leftHumerus;
        bones[12] = leftUlna;
        bones[13] = leftRadius;
        bones[14] = leftHand;
        bones[15] = rightFemur;
        bones[16] = rightFibula;
        bones[17] = leftTibia;
        bones[18] = rightPatella;
        bones[19] = rightFoot;
        bones[20] = leftFemur;
        bones[21] = leftFibula;
        bones[22] = leftTibia;
        bones[23] = leftPatella;
        bones[24] = leftFoot;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeColor()
    {
        //for(int i = 0; i< manager.gameObject.GetComponent<GameManager>().bones.Length(); i++){}
    }
}
