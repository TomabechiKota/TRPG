using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Mgr : MonoBehaviour {

	[SerializeField]
    GameObject Dice_image;
    [SerializeField]
	GameObject parentObj;
	GameObject dice_image;
	
	Dice dice_image_script;
	List<Dice> Dice_images = new List<Dice>();

	int[] dices = new int[22];
	int STR = 0;
	int CON = 0;
	int POW = 0;
	int DEX = 0;
	int APP = 0;
	int SIZ = 6;
	int INTe = 6;
	int EDU = 3;

	int SAN = 0;
	int LUCK = 0;
	int IDEA = 0;
	int knw = 0;
	string db = "0";
	int MP = 0;
	int HP = 0;
	int job = 0;//edu*20
	int hobby = 0;//int*20

	// Use this for initialization
	void Start () {
		float w = Screen.width;
		float h = Screen.height;
		float gap_x = (w*32.0f)/629;
		float gap_y = (h*28.75f)/427;
		for(int i = 0;i<8;i++){
			for(int j = 0;j<3;j++){
				if((i == 5|| i ==6)&&j == 2){
					continue;
				}
				dice_image = Instantiate(Dice_image,parentObj.transform);
				Vector3 pos = dice_image.transform.position;
				pos.x += (j*gap_x);
				pos.y -= (i*gap_y);
				dice_image.transform.position = pos;
				dice_image_script = dice_image.GetComponent<Dice>();
				Dice_images.Add(dice_image_script);
			}
		}
		Roll_all();
	}
	public void Roll_all(){
		for(int i = 0;i < 22;i++){
			dices[i] = Random.Range(1,7);
			Dice_images[i].Set_num(dices[i]);
		}
		cal_all();
	}

	public void ReRoll_STR(){
		dices[0] = Random.Range(1,7);
		dices[1] = Random.Range(1,7);
		dices[2] = Random.Range(1,7);
		Dice_images[0].Set_num(dices[0]);
		Dice_images[1].Set_num(dices[1]);
		Dice_images[2].Set_num(dices[2]);
		cal_STR();
	}
	public void ReRoll_CON(){
		dices[3] = Random.Range(1,7);
		dices[4] = Random.Range(1,7);
		dices[5] = Random.Range(1,7);
		Dice_images[3].Set_num(dices[3]);
		Dice_images[4].Set_num(dices[4]);
		Dice_images[5].Set_num(dices[5]);
		cal_CON();
	}
	public void ReRoll_POW(){
		dices[6] = Random.Range(1,7);
		dices[7] = Random.Range(1,7);
		dices[8] = Random.Range(1,7);
		Dice_images[6].Set_num(dices[6]);
		Dice_images[7].Set_num(dices[7]);
		Dice_images[8].Set_num(dices[8]);
		cal_POW();
	}
	public void ReRoll_DEX(){
		dices[9] = Random.Range(1,7);
		dices[10] = Random.Range(1,7);
		dices[11] = Random.Range(1,7);
		Dice_images[9].Set_num(dices[9]);
		Dice_images[10].Set_num(dices[10]);
		Dice_images[11].Set_num(dices[11]);
		cal_DEX();
	}
	public void ReRoll_APP(){
		dices[12] = Random.Range(1,7);
		dices[13] = Random.Range(1,7);
		dices[14] = Random.Range(1,7);
		Dice_images[12].Set_num(dices[12]);
		Dice_images[13].Set_num(dices[13]);
		Dice_images[14].Set_num(dices[14]);
		cal_APP();
	}
	public void ReRoll_SIZ(){
		dices[15] = Random.Range(1,7);
		dices[16] = Random.Range(1,7);
		Dice_images[15].Set_num(dices[15]);
		Dice_images[16].Set_num(dices[16]);
		cal_SIZ();
	}
	public void ReRoll_INTe(){
		dices[17] = Random.Range(1,7);
		dices[18] = Random.Range(1,7);
		Dice_images[17].Set_num(dices[17]);
		Dice_images[18].Set_num(dices[18]);
		cal_INTe();
	}
	public void ReRoll_EDU(){
		dices[19] = Random.Range(1,7);
		dices[20] = Random.Range(1,7);
		dices[21] = Random.Range(1,7);
		Dice_images[19].Set_num(dices[19]);
		Dice_images[20].Set_num(dices[20]);
		Dice_images[21].Set_num(dices[21]);
		cal_EDU();
	}

	void cal_all(){
		cal_STR();
		cal_CON();
		cal_POW();
		cal_DEX();
		cal_APP();
		cal_SIZ();
		cal_INTe();
		cal_EDU();
	}
	void cal_STR(){
		STR = dices[0]+dices[1]+dices[2];
		Set_db();
	}
	void cal_CON(){
		CON = dices[3]+dices[4]+dices[5];
		HP= (SIZ + CON)/2;
	}
	void cal_POW(){
		POW = dices[6]+dices[7]+dices[8];
		SAN = POW*5;
		LUCK = SAN;
		MP = POW;
	}
	void cal_DEX(){DEX = dices[9]+dices[10]+dices[11];}
	void cal_APP(){APP = dices[12]+dices[13]+dices[14];}
	void cal_SIZ(){
		SIZ = dices[15]+dices[16]+6;
		HP= (SIZ + CON)/2;
		Set_db();
	}
	void cal_INTe(){
		INTe = dices[17]+dices[18]+6;
		IDEA = INTe*5;
		hobby = INTe*10;
	}
	void cal_EDU(){
		EDU = dices[19]+dices[20]+dices[21]+3;
		knw = EDU*5;
		job = EDU*20;
	}

	void Set_db(){
		int sum = STR + SIZ;
		if(sum <= 12){
			db = "-1d6";
		}else if(sum <=16){
			db = "-1d4";
		}else if(sum <=24){
			db = "0";
		}else if(sum <=32){
			db = "1d4";
		}else if(sum <=40){
			db = "1d6";
		}
	}

	public string state(){return STR+"\n"+CON+"\n"+POW+"\n"+DEX+"\n"+APP+"\n"+SIZ+"\n"+INTe+"\n"+EDU;}
	public string other(){return SAN+"\n"+LUCK+"\n"+IDEA+"\n"+knw+"\n"+db+"\n"+MP+"\n"+HP+"\n"+job+"\n"+hobby;}

	public int[] all_state(){
		cal_all();
		int[] states = new int[16];
		states[0] = STR;
		states[1] = CON;
		states[2] = POW;
		states[3] = DEX;
		states[4] = APP;
		states[5] = SIZ;
		states[6] = INTe;
		states[7] = EDU;
		states[8] = SAN;
		states[9] = LUCK;
		states[10] = IDEA;
		states[11] = knw;
		states[12] = MP;
		states[13] = HP;
		states[14] = job;
		states[15] = hobby;
		return states;
	}
	public string Get_db(){
		return db;
	}

}
