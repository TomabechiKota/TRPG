using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Button_Mgr : MonoBehaviour {
	int SKILL_NUM = 0;
	int LIMIT = 85;
    [SerializeField]
    GameObject P_button;
    [SerializeField]
    GameObject P10_button;
    [SerializeField]
    GameObject MAX_button;
    [SerializeField]
    GameObject M_button;
    [SerializeField]
    GameObject M10_button;
    [SerializeField]
    GameObject MIN_button;
    [SerializeField]
	GameObject parentObj;

	//List<GameObject> buttons = new List<GameObject>();
	GameObject button;
	Messenger messenger;

	List<string> skill_names = new List<string>();
	List<int> skill_points = new List<int>();
	List<int> skill_points_j = new List<int>();
	List<int> original_skill_points = new List<int>();
	
	int h_point_max = 0;
	int h_point = 0;

    // Start is called before the first frame update
    void Start(){
		messenger =  GameObject.Find("Messenger").GetComponent<Messenger>();
		Get_Skill_Data();
		float h = Screen.height;
		float gap_y = (h*26.25f)/427;
		for(int i = 0;i<SKILL_NUM;i++){
			if(skill_names[i] == "クトゥルフ神話"){
				continue;
			}
			button = Instantiate(P_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(1,i,1);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			if(skill_names[i] == "クトゥルフ神話"){
				continue;
			}
			button = Instantiate(P10_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(10,i,1);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			if(skill_names[i] == "クトゥルフ神話"){
				continue;
			}
			button = Instantiate(MAX_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(100,i,1);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			if(skill_names[i] == "クトゥルフ神話"){
				continue;
			}
			button = Instantiate(M_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(-1,i,1);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			if(skill_names[i] == "クトゥルフ神話"){
				continue;
			}
			button = Instantiate(M10_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(-10,i,1);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			if(skill_names[i] == "クトゥルフ神話"){
				continue;
			}
			button = Instantiate(MIN_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(-100,i,1);
			//buttons.Add(button);
		}
		
    }

	void Get_Skill_Data(){
		skill_names = messenger.Get_s_n();
		original_skill_points = messenger.Get_o_s_p();
		skill_points = messenger.Get_s_p();
		skill_points_j = messenger.Get_s_p_j();
		h_point_max = messenger.Get_hobby_point();
		h_point = h_point_max;
		SKILL_NUM = messenger.SKILL_NUM();
	}

	public int Get_count(){
		return SKILL_NUM;
	}

	public string Get_skill_name(int i){
		return skill_names[i];
	}

	public int Get_skill_point(int i){
		return skill_points[i]+original_skill_points[i]+skill_points_j[i];
	}
	
	public List<int> Get_skill_points(){
		return skill_points;
	}
	
	
	int sum_skill_point(){
		int s_sp = 0;
		for(int i = 0;i<SKILL_NUM;i++){
			s_sp += skill_points[i];
		}
		return s_sp;
	}

	public void click(int type,int num){
		switch(type){
			case 1:
			if(skill_points[num]+original_skill_points[num]+skill_points_j[num]<LIMIT){
				skill_points[num]+=1;
			}
			break;
			case 10:
			if(skill_points[num]+original_skill_points[num]+skill_points_j[num] + 10 <=LIMIT){
				skill_points[num]+=10;
			}else{
				skill_points[num] = LIMIT - original_skill_points[num]-skill_points_j[num];
			}
			break;
			case 100:
			skill_points[num] = LIMIT - original_skill_points[num]-skill_points_j[num];
			break;
			case -1:
			if(skill_points[num]>0){
				skill_points[num]-=1;
			}
			break;
			case -10:
			if(skill_points[num]>10){
				skill_points[num]-=10;
			}else{
				skill_points[num] = 0;
			}
			break;
			case -100:
			skill_points[num] = 0;
			break;
		}
		h_point = h_point_max - sum_skill_point();
	}

	public int Get_h_point(){
		return h_point;
	}

	public void Reset_point(){
		for(int i = 0;i<SKILL_NUM;i++){
			skill_points[i] = 0;
		}
		h_point = h_point_max - sum_skill_point();
	}

	public bool next_oK(){
		if(h_point == 0){
			return true;
		}
		return false;
	}

}