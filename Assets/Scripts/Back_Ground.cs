using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back_Ground : MonoBehaviour {
    [SerializeField]
	Image image;
	Messenger messenger;
	// Use this for initialization
	void Start () {
		messenger = GameObject.Find("Messenger").GetComponent<Messenger>();
		image.sprite=messenger.Get_Back_ground();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
