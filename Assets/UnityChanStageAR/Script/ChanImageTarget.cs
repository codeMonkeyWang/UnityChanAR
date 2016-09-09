using UnityEngine;
using System.Collections;
using EasyAR;

public class ChanImageTarget : ImageTargetBehaviour {

	public ImageTargetBehaviour musicOnTarget;
	public ImageTargetBehaviour musicOffTarget;
	public ImageTargetBehaviour stageImageTarget;

	public chanMusic musicPlayer ;
	public GameObject musicUI;

	protected override void Awake()
	{
		base.Awake();
		TargetFound += OnTargetFound;
		TargetLost += OnTargetLost;
		// TargetLoad += OnTargetLoad;
		// TargetUnload += OnTargetUnload;
		
	}
	protected override void Start()
	{
		base.Start();
		HideObjects(transform);
	}
	
	void HideObjects(Transform trans)
	{
		for (int i = 0; i < trans.childCount; ++i)
			HideObjects(trans.GetChild(i));
		if (transform != trans)
			gameObject.SetActive(false);
	}

	void ShowObjects(Transform trans)
	{
		for (int i = 0; i < trans.childCount; ++i)
			ShowObjects(trans.GetChild(i));
		if (transform != trans)
			gameObject.SetActive(true);
	}

	void OnTargetFound(ImageTargetBaseBehaviour behaviour)
	{
		musicOnTarget.gameObject.SetActive(true);
		musicOffTarget.gameObject.SetActive(true);
		stageImageTarget.gameObject.SetActive(true);
		musicPlayer.StartMusic();
		ShowObjects(transform);
	}

	void OnTargetLost(ImageTargetBaseBehaviour behaviour)
	{
		musicOnTarget.gameObject.SetActive(false);
		musicOffTarget.gameObject.SetActive(false);
		stageImageTarget.gameObject.SetActive(false);
		musicUI.SetActive(false);
		musicPlayer.stopMusic();
		musicPlayer.setVolume(0);
		HideObjects(transform);
		
	}
}
