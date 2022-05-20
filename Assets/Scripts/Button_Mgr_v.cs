using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Mgr_v : MonoBehaviour {
    [SerializeField]
    GameObject P_button;
    [SerializeField]
    GameObject M_button;
    [SerializeField]
	GameObject parentObj;
	GameObject button;
    [SerializeField]
	Text_Mgr_v T_Mgr_v;
	
	// Use this for initialization
	void Start () {
//        Debug.Log("Screen Width : " + Screen.width);//629
//        Debug.Log("Screen  height: " + Screen.height);//427
		float w = Screen.width;
		float h = Screen.height;
		float diff_px = (w*60)/629;
		float diff_mx = (w*97)/629;
		float diff_y = (h*35)/427;
		float gap_y = (h*53.0f)/427;
		for(int i = 0;i < 3;i++){
			button = Instantiate(P_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.x += diff_px;
			pos.y -= (diff_y+i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(1,i,2);
		}
		for(int i = 0;i < 3;i++){
			button = Instantiate(M_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.x += diff_mx;
			pos.y -= (diff_y+i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(-1,i,2);
		}
	}
	
	public void click(int type,int num){
		T_Mgr_v.C_change(type,num);
	}
}
