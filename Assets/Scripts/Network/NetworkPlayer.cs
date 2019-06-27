using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour {

	bool isAlive = true;

	Vector3 position;
	Quaternion rotation;

	float lerpSmoothing = 5f;

	void Start () {
		if(photonView.isMine){
			GetComponent<Movement>().enabled = true;
		}
		else{
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting){
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else{
			position = (Vector3)stream.ReceiveNext();
			rotation = (Quaternion)stream.ReceiveNext();
		}
	}
	
	void Update () {
	}

	IEnumerator Alive(){
		while(isAlive){
			transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * lerpSmoothing);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * lerpSmoothing);

			yield return null;
		}
	}
}
