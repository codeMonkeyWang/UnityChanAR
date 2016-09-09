using UnityEngine;
using System.Collections;
using EasyAR;

public class MusicImageTargetOn : MusicImageTargetBase {


	bool isFound = false;

	protected override void Awake()
	{
		base.Awake();
		TargetFound += OnTargetFound;
		TargetLost += OnTargetLost;
		TargetLoad += OnTargetLoad;
		
	}
	void Update () {

		if(isFound){
			musicSlider.value -= (posZ-transform.position.z)*0.1f;
			posZ = transform.position.z;
		}
	}

	void OnTargetFound(ImageTargetBaseBehaviour behaviour)
	{
		musicUI.SetActive(true);
		isFound = true;
	}
	void OnTargetLost(ImageTargetBaseBehaviour behaviour)
	{
		isFound = false;
	}

	void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
	{
		posZ = transform.position.z;
	}
}
