using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class HandButtons : MonoBehaviour {

    public GameObject objectToSpawn;
    public GameObject spawnBonePoint;
    public GameObject manager;

	void Start () {
        this.gameObject.layer = 9;
    }
	
	void Update () {
        manager = GameObject.Find("gameManager");
    }

    public void TouchButtonHand()//Instancia un hueso dependiendo del tipo
    {
        GameObject bone = Instantiate(objectToSpawn, spawnBonePoint.transform.position, Quaternion.identity);

        bone.GetComponent<InteractionBehaviour>().manager = GameObject.Find("Interaction Manager").GetComponent<InteractionManager>();

        StartCoroutine("destroyBone", bone);
    }

    public void TouchButtonMenu()
    {
        manager.gameObject.GetComponent<GameManager>().restartAll();
    }

    public void TouchButtonHelp()
    {
        manager.gameObject.GetComponent<GameManager>().helpBones();
    }

    public void TouchButtonUnlock()
    {
        manager.gameObject.GetComponent<GameManager>().unlockBones();
    }

    IEnumerator destroyBone(GameObject bone)
    {
        yield return new WaitForSeconds(8);

        Destroy(bone);

        yield return null;
    }
}
