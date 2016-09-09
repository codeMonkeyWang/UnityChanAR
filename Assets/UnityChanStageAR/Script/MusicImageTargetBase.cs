using UnityEngine;
using System.Collections;
using EasyAR;
using UnityEngine.UI;

public class MusicImageTargetBase : ImageTargetBehaviour {

	public GameObject musicUI;
	public chanMusic music;


	//音量的显示条
	protected Slider musicSlider;

	//transform z的坐标
	protected float posZ;

	protected override void Awake()
	{
		base.Awake();
		musicSlider = musicUI.GetComponentInChildren<Slider>();
		
	}
	protected override void Start()
	{
		base.Start();
	}

}
