using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public GameObject bulletPrefab;
	private float speed;
	private float x;
	private float z;
	// Use this for initialization
	void Start () {
		speed = 10.0f;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!isLocalPlayer)
            return;

        if(Input.GetKey(KeyCode.W)) {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward*speed;
        	//this.gameObject.transform.Translate((-1)*this.gameObject.transform.forward*speed*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S)) {
            this.gameObject.GetComponent<Rigidbody>().velocity = (-1)*this.gameObject.transform.forward*speed;
        	//this.gameObject.transform.Translate(this.gameObject.transform.forward*speed*Time.deltaTime);
        }
        else {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if(Input.GetKey(KeyCode.A)) {
        	float x = this.gameObject.transform.localEulerAngles.y + speed;
			float y = this.gameObject.transform.localEulerAngles.x;
			this.gameObject.transform.localEulerAngles = new Vector3(y,x,0);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    [Command] // 发射子弹变为联网功能
    void CmdFire()
    {
        // create the bullet object from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            new Vector3(this.gameObject.transform.position.x, 1.5f, this.gameObject.transform.position.z)
			+ this.gameObject.transform.forward * 1.5f,
            Quaternion.identity);
        bullet.transform.forward = this.gameObject.transform.forward;
        // make the bullet move away in front of the player
        // 这里如果设置的是速度 不需要 network send rate，但如果是force，则需要
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed * 10;
       
        NetworkServer.Spawn(bullet);
        // make bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);        
    }
}
