using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CameraController : MonoBehaviour {
	private NetworkPlayer player;
	private Vector3 offset;//it's a vector from player to camera
	//offset can be obtained by transform(camera) - player
	// Use this for initialization

	void OnPlayerConnected(NetworkPlayer player) {
		int playerID = int.Parse(player.ToString());
		Debug.Log(playerID);
		/*offset = transform.position - player.transform.position;

        Debug.Log(offset);*/
    }

	// Update is called once per frame
	void LateUpdate () {
		//transform.position = player.transform.position + offset;
	}
}
