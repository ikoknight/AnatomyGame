using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBone : MonoBehaviour {

	void Start () {
        StartCoroutine("destroyBone");
    }

    void Update () {
		
	}
    IEnumerator destroyBone()
    {
        yield return new WaitForSeconds(60);

        Destroy(this.gameObject);

        yield return null;
    }
}
