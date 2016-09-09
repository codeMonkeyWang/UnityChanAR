using UnityEngine;
using System.Collections;
using EasyAR;

public class MusicImageTargetOff : MusicImageTargetBase {


	protected override void Awake()
	{
		base.Awake();
		TargetFound += OnTargetFound;;
		
	}
	void OnTargetFound(ImageTargetBaseBehaviour behaviour)
	{
		musicUI.SetActive(false);
		music.setVolume(0);
	}
	
}
