using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test : MonoBehaviour {

	public int _exp = 0;

	void Start () {
		List<Dictionary<string,object>> data = CSVReader.Read("GdCandyInfo");

		for(var i=0; i< data.Count; i++){
			Debug.Log("id" + (i).ToString() + " : " + data[i]["name"] + " " + data[i]["prefabs"] + " " + data[i]["dropRate"]+" " + data[i]["Speed"]);
		}

		_exp = (int)data[0]["id"];
		Debug.Log("id");
     
	}
}
