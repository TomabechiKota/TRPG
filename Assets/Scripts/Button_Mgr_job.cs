using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Mgr_job : MonoBehaviour {
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
	GameObject button;
	Messenger messenger;

	List<int> OnOff = new List<int>();
	List<string> skill_names = new List<string>();
	List<int> skill_points = new List<int>();
	List<int> original_skill_points = new List<int>();

	int j_point_max = 0;
	int j_point = 0;

	// Use this for initialization
	void Start () {
		messenger =  GameObject.Find("Messenger").GetComponent<Messenger>();
		Get_Skill_Data();
		float h = Screen.height;
		float gap_y = (h*26.25f)/427;
		for(int i = 0;i<SKILL_NUM;i++){
			button = Instantiate(P_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(1,i,0);
		}for(int i = 0;i<SKILL_NUM;i++){
			button = Instantiate(P10_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(10,i,0);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			button = Instantiate(MAX_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(100,i,0);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			button = Instantiate(M_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(-1,i,0);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			button = Instantiate(M10_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(-10,i,0);
			//buttons.Add(button);
		}for(int i = 0;i<SKILL_NUM;i++){
			button = Instantiate(MIN_button,parentObj.transform);
			Vector3 pos = button.transform.position;
			pos.y -= (i*gap_y);
			button.transform.position = pos;
			button.GetComponent<button>().set_type(-100,i,0);
			//buttons.Add(button);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Get_Skill_Data(){
		for(int i = 0;i<messenger.SKILL_NUM();i++){
			if(messenger.Get_OnOff(i) == 1){
				OnOff.Add(i);
			}
		}
		skill_names = messenger.Get_s_n();
		original_skill_points = messenger.Get_o_s_p();
		skill_points = messenger.Get_s_p_j();
		j_point_max = messenger.Get_job_point();
		j_point = j_point_max;
		SKILL_NUM = OnOff.Count;
	}

	int sum_skill_point(){
		int s_sp = 0;
		for(int i = 0;i<messenger.SKILL_NUM();i++){
			s_sp += skill_points[i];
		}
		return s_sp;
	}
	
	public void click(int type,int n){
		int num = OnOff[n];
		switch(type){
			case 1:
			if(skill_points[num]+original_skill_points[num]<LIMIT){
				skill_points[num]+=1;
			}
			break;
			case 10:
			if(skill_points[num]+original_skill_points[num] + 10 <=LIMIT){
				skill_points[num]+=10;
			}else{
				skill_points[num] = LIMIT - original_skill_points[num];
			}
			break;
			case 100:
			skill_points[num] = LIMIT - original_skill_points[num];
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
		j_point = j_point_max - sum_skill_point();
	}
	
	public int Get_count(){
		return SKILL_NUM;
	}
	
	public string Get_skill_name(int i){
		return skill_names[OnOff[i]];
	}

	public int Get_skill_point(int i){
		return skill_points[OnOff[i]]+original_skill_points[OnOff[i]];
	}
	public List<int> Get_skill_points(){
		return skill_points;
	}

	public int Get_j_point(){
		return j_point;
	}

	bool skill_full(){
		for(int i = 0;i < SKILL_NUM;i++){
			if(skill_points[OnOff[i]]+original_skill_points[OnOff[i]] != LIMIT){
				return false;
			}
		}
		return true;
	}

	public string Get_job_name(){
		return messenger.Get_job_name();
	}

	public void Reset_point(){
		for(int i = 0;i<SKILL_NUM;i++){
			skill_points[i] = 0;
		}
		j_point = j_point_max - sum_skill_point();
	}

	public bool next_oK(){
		if(j_point == 0){
			return true;
		}if(j_point < 0){
			return false;
		}else if(skill_full()){
			return true;
		}
		return false;
	}
}
