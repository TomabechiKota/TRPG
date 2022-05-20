using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Text_Mgr_v : MonoBehaviour {

    [SerializeField]
    Text Player_names;
    [SerializeField]
    Text current_state;
    [SerializeField]
    Text state;
    [SerializeField]
    Text other_state;
    [SerializeField]
    Text job_And_hobby;
    [SerializeField]
    Text j_skill;
    [SerializeField]
    Text j_skill_point;
    [SerializeField]
    Text h_skill;
    [SerializeField]
    Text h_skill_point;
    [SerializeField]
    Text skill;
    [SerializeField]
    Text skill_point;
    [SerializeField]
    Text search_result_name;
    [SerializeField]
    Text search_result_point;
    [SerializeField]
    Text item_text;
    [SerializeField]
    Text intro_text;
    [SerializeField]
	InputField inputField_search;
    [SerializeField]
	InputField inputField_MEMO;
	Messenger messenger;

	TextAsset txtFile;
	TextAsset csvFile;
	string line;

	List<string> DataNames = new List<string>();
	List<string> Datas = new List<string>();

	List<string> j_DataNames = new List<string>();
	List<int> j_Datas = new List<int>();

	List<string> h_DataNames = new List<string>();
	List<int> h_Datas = new List<int>();

	List<int> C_state = new List<int>();
	List<string> infos_item = new List<string>();
	List<string> infos_intro = new List<string>();

	List<string> reward_Names = new List<string>();
	List<int> reward_Datas = new List<int>();

	List<string> Memo = new List<string>();

	int cthulhu = 0;
	int san_max = 99;

	int phase = 0;
	
	List<int> original_skill_points = new List<int>();
	List<string> skill_names = new List<string>();
	int skill_num = 0;
	/*
	List<int> skill_points = new List<int>();
	List<int> skill_points_j = new List<int>();
	List<int> OnOff = new List<int>();*/



	// Use this for initialization
	void Start () {		
		messenger = GameObject.Find("Messenger").GetComponent<Messenger>();
		Read_Player_Data();
		Read_Skill_Data();
		draw_fist();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Read_Skill_Data(){
		//csvFile = Resources.Load("csv_files/skill") as TextAsset;//指定したファイルをTextAssetとして読み込み(ファイル名の.csvは不要なことに注意)　最初の行（タイトル部分）も読み込まれるのでそこは使用しない
        //StringReader reader = new StringReader(csvFile.text);//
		StreamReader reader = new StreamReader("input/skill.csv", System.Text.Encoding.GetEncoding("UTF-8"));
		line = reader.ReadLine();
		while (reader.Peek() != -1){//最後まで読み込むと-1になる関数
            line = reader.ReadLine();//一行ずつ読み込み
			Read_Data(line.Split(','));
		}
		skill_num = original_skill_points.Count;
	}

	void Read_Data(string[] splited_line){
		skill_names.Add(splited_line[0]);
		int h_contein = 0;
		int j_contein = 0;
		int r_contein = 0;
		int j_p = 0;
		int h_p = 0;
		int r_p = 0;
		h_contein = h_DataNames.IndexOf(splited_line[0]);
		j_contein = j_DataNames.IndexOf(splited_line[0]);
		r_contein = reward_Names.IndexOf(splited_line[0]);
		if(h_contein != -1){
			h_p = h_Datas[h_contein];
		}if(j_contein != -1){
			j_p = j_Datas[j_contein];
		}if(r_contein != -1){
			r_p = reward_Datas[r_contein];
		}
		if(h_contein != -1 && j_contein != -1){
			original_skill_points.Add(h_p + j_p - int.Parse(splited_line[1]) + r_p);
		}else if(h_contein != -1 || j_contein != -1){
			original_skill_points.Add(h_p + j_p + r_p);
		}else{
			if(splited_line[0] == "回避"){
				original_skill_points.Add(int.Parse(Datas[9])*2 + r_p);
			}
			else if(splited_line[0] == "母国語"){
				original_skill_points.Add(int.Parse(Datas[13])*5 + r_p);
			}else{
				original_skill_points.Add(int.Parse(splited_line[1]) + r_p);
			}
		}
	}


	void Read_Player_Data(){
		//txtFile = Resources.Load("output/PlayerData") as TextAsset;//指定したファイルをTextAssetとして読み込み(ファイル名の.csvは不要なことに注意)　最初の行（タイトル部分）も読み込まれるのでそこは使用しない
        //StringReader reader = new StringReader(txtFile.text);//
		string file_name = messenger.Get_player_name_f();
		StreamReader reader = new StreamReader("./output/"+file_name+".txt", System.Text.Encoding.GetEncoding("UTF-8"));
		while (reader.Peek() != -1){//最後まで読み込むと-1になる関数
            line = reader.ReadLine();//一行ずつ読み込み
			Set_Data(line.Split('\t'));
		}
	}

	void Set_Data(string[] splited_line){
		if(splited_line[0] == "職業技能"){
			phase = 1;
			return;
		}
		if(splited_line[0] == "趣味技能"){
			phase = 2;
			return;
		}
		if(splited_line[0] == "現在のSAN"){
			phase = 3;
		}
		if(splited_line[0] == "持ち物など"){
			phase = 4;
			return;
		}
		if(splited_line[0] == "紹介"){
			phase = 5;
			return;
		}
		if(splited_line[0] == "MEMO"){
			phase = 6;
			return;
		}
		if(splited_line[0] == "報酬"){
			phase = 7;
			return;
		}
		if(phase == 0){
			DataNames.Add(splited_line[0]);
			Datas.Add(splited_line[1]);
		}else if(phase == 1){
			j_DataNames.Add(splited_line[0]);
			j_Datas.Add(int.Parse(splited_line[1]));
		}else if(phase == 2){
			h_DataNames.Add(splited_line[0]);
			h_Datas.Add(int.Parse(splited_line[1]));
		}else if(phase == 3){
			C_state.Add(int.Parse(splited_line[1].Split('/')[0]));
		}else if(phase == 4){
			infos_item.Add(splited_line[0]);
		}else if(phase == 5){
			infos_intro.Add(splited_line[0]);
		}else if(phase == 6){
			Memo.Add(splited_line[0]);
		}else if(phase == 7){
			reward_Names.Add(splited_line[0]);
			reward_Datas.Add(int.Parse(splited_line[1]));
			if(splited_line[0] == "クトゥルフ神話"){
				cthulhu = int.Parse(splited_line[1]);
				san_max = 99 - cthulhu;
			}
		}
	}

	public void close_view(){
		string file_name = Datas[0].Replace(" ","");
		file_name = file_name.Replace("　","");
		file_name = file_name.Replace(".","");
		file_name = file_name.Replace(",","");
		StreamWriter sw = new StreamWriter("./output/"+file_name+".txt",false); // TextData.txtというファイルを新規で用意
        for(int i = 0;i < Datas.Count;i++){
			sw.WriteLine(DataNames[i]+"\t"+Datas[i]);
		}
		sw.WriteLine("職業技能");
		for(int i = 0;i < j_Datas.Count;i++){
			sw.WriteLine(j_DataNames[i]+"\t"+j_Datas[i]);
		}
		sw.WriteLine("趣味技能");
		for(int i = 0;i < h_Datas.Count;i++){
			sw.WriteLine(h_DataNames[i]+"\t"+h_Datas[i]);
		}
		sw.WriteLine("現在のSAN\t"+C_state[0]+"/"+san_max+"\n現在のマジック・ポイント\t"+C_state[1]+"/"+Datas[19]+"\n現在の耐久力\t"+C_state[2]+"/"+Datas[20]);
		sw.WriteLine("持ち物など");
		foreach(string info in infos_item){
			sw.WriteLine(info);
		}
		sw.WriteLine("紹介");
		foreach(string info in infos_intro){
			sw.WriteLine(info);
		}
		sw.WriteLine("MEMO");
		sw.WriteLine(inputField_MEMO.text);
		sw.Flush();
        sw.Close();
	}

	void draw_fist(){
		Player_names.text = "名前   "+Datas[0]+"\n性別   "+Datas[1]+"\n年齢   "+Datas[2]+"\n出身   "+Datas[3];
		job_And_hobby.text = "職業   "+Datas[4]+"\n趣味   "+Datas[5];
		state.text = "";
		for(int i = 6;i < 14;i++){
			state.text += (Datas[i]+"\n");
		}
		other_state.text = "";
		for(int i = 14;i < Datas.Count;i++){
			other_state.text += (Datas[i]+"\n");
		}
		j_skill.text = "";
		foreach(string d in j_DataNames){
			j_skill.text += (d+"\n");
		}
		j_skill_point.text = "";
		foreach(int d in j_Datas){
			j_skill_point.text += (d+"\n");
		}
		h_skill.text = "";
		foreach(string d in h_DataNames){
			h_skill.text += (d+"\n");
		}
		h_skill_point.text = "";
		foreach(int d in h_Datas){
			h_skill_point.text += (d+"\n");
		}
		skill.text = "";
		skill_point.text = "";
		for(int i = 0;i < skill_num;i++){
			skill.text += (skill_names[i]+"\n");
			skill_point.text += (original_skill_points[i]+"\n");
		}item_text.text = "";
		foreach(string info in infos_item){
			item_text.text += (info+"\n");
		}intro_text.text = "";
		foreach(string info in infos_intro){
			intro_text.text += (info+"\n");
		}
		foreach(string memo in Memo){
			inputField_MEMO.text += (memo+"\n");
		}
		draw_C_state();
	}

	void draw_C_state(){
		current_state.text = "現在値\nSAN\n"+C_state[0]+"/"+san_max+"\nMP\n"+C_state[1]+"/"+Datas[19]+"\n耐久力\n"+C_state[2]+"/"+Datas[20];
	}

	public void C_change(int type,int num){
		if(type == 1){
			C_state[num]++;
		}else if(type == -1){
			C_state[num]--;
		}
		if(C_state[0] > san_max){
			C_state[0] = san_max;
		}
		if(C_state[1] > int.Parse(Datas[19])){
			C_state[1] = int.Parse(Datas[19]);
		}
		if(C_state[2] > int.Parse(Datas[20])){
			C_state[2] = int.Parse(Datas[20]);
		}
		draw_C_state();
	}

	public void draw_search(){
		string search = inputField_search.text;
		int s_r_num = skill_names.IndexOf(search);
		if(s_r_num != -1){
			search_result_name.text = ""+skill_names[s_r_num];
			search_result_point.text = ""+original_skill_points[s_r_num];
		}else{
			search_result_name.text = "見つかりませんでした";
			search_result_point.text = "";
		}
	}

}
