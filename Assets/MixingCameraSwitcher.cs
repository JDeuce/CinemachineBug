using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MixingCameraSwitcher : MonoBehaviour {

	public float transitionTime = 2;
	public SpriteRenderer player;
	public Transform wall;

	public float FarThreshold = 5;
	public float Distance; // for easy inspector access


	private bool isFar;

	private CinemachineMixingCamera mixingCamera;

	void Start() {
		mixingCamera = GetComponent<CinemachineMixingCamera>();
	}

	// Update is called once per frame
	void Update () {

		Distance = Vector2.Distance(player.transform.position, wall.position);

		isFar = Distance > FarThreshold;

		float rate = Time.deltaTime / transitionTime;

		if (Distance > FarThreshold) {
			mixingCamera.m_Weight0 = Mathf.Clamp01(mixingCamera.m_Weight0 - rate);
			mixingCamera.m_Weight1 = Mathf.Clamp01(mixingCamera.m_Weight1 + rate);
		} else {
			mixingCamera.m_Weight1 = Mathf.Clamp01(mixingCamera.m_Weight1 - rate);
			mixingCamera.m_Weight0 = Mathf.Clamp01(mixingCamera.m_Weight0 + rate);
		}
	}
}
