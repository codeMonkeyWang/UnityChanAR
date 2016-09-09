using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PosText : MonoBehaviour {

	public Text textUI;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		textUI.text = " x:"+transform.position.x+"/n y:"+transform.position.y+"/n z:"+transform.position.z;
	}
}
