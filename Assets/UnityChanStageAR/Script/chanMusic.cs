using UnityEngine;
using System.Collections;

public class chanMusic : MonoBehaviour {

	public GameObject musicplayerPrefab;
	
	[HideInInspector]
	public GameObject musicPlayer;

	void Awake(){
		musicPlayer = (GameObject)Instantiate(musicplayerPrefab);
		setVolume(0);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartMusic()
    {
        foreach (var source in musicPlayer.GetComponentsInChildren<AudioSource>())
            source.Play();
    }	
	public void stopMusic()
    {
        foreach (var source in musicPlayer.GetComponentsInChildren<AudioSource>())
            source.Stop();
    }

	public void setVolume(float value){
		foreach (var source in musicPlayer.GetComponentsInChildren<AudioSource>())
            source.volume = value;
	}
}
