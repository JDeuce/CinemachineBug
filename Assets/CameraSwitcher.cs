using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour {

	public CinemachineVirtualCamera closeCam;
	public CinemachineVirtualCamera farCam;

	public int activePriority = 11;
	public int inactivePriority = 10;

	public SpriteRenderer player;
	public Transform wall;

	public float FarThreshold = 5;
	public float Distance; // for easy inspector access

	// Update is called once per frame
	void Update () {

		Distance = Vector2.Distance(player.transform.position, wall.position);

		if (Distance > FarThreshold) {
			farCam.m_Priority = activePriority;
			closeCam.m_Priority = inactivePriority;
		} else {
			closeCam.m_Priority = activePriority;
			farCam.m_Priority = inactivePriority;
		}
	}
}
