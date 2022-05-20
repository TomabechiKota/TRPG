using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_Mgr : MonoBehaviour {
    [SerializeField]
    GameObject Toggle_Button;
    [SerializeField]
	GameObject parentObj;
	GameObject toggle_button;
	Messenger messenger;
	List<int> OnOff = new List<int>();
	int On_Count = 0;
	int MAX = 8;
	int MIN = 4;
	int SKILL_NUM = 0;
	// Use this for initialization
	void Start () {
		messenger =  GameObject.Find("Messenger").GetComponent<Messenger>();
		SKILL_NUM = messenger.SKILL_NUM();

		float h = Screen.height;
		float gap_y = (h*26.25f)/427;

		for(int i = 0;i<SKILL_NUM;i++){
			OnOff.Add(0);
			if(messenger.Get_s_n()[i] == "クトゥルフ神話"){
				continue;
			}
			toggle_button = Instantiate(Toggle_Button,parentObj.transform);
			Vector3 pos = toggle_button.transform.position;
			pos.y -= (i*gap_y);
			toggle_button.transform.position = pos;
			toggle_button.GetComponent<Toggle_script>().set_num(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void togle_On(){
		On_Count++;
	}
	void togle_Off(){
		On_Count--;
	}

	public void change(int i){
		if(OnOff[i] == 0){
			OnOff[i] = 1;
			togle_On();
		}else if(OnOff[i] == 1){
			OnOff[i] = 0;
			togle_Off();
		}
	}
	public List<int> get_OnOff(){
		return OnOff;
	}

	public bool next_oK(){
		if(On_Count<=MAX&&On_Count>=MIN){
			return true;
		}
		return false;
	}

	public int Get_OnCount(){
		return On_Count;
	}
}
