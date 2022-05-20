using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class View_Mgr : MonoBehaviour {
	Messenger messenger;
    [SerializeField]
	Text_Mgr_v T_Mgr_v;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click_Close(){
		T_Mgr_v.close_view();
		Application.Quit();
	}
}
