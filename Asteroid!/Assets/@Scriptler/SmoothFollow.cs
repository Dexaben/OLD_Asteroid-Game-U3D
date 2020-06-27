using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {
	[SerializeField]Transform target;
	[SerializeField] Vector3 defaultDistance=new Vector3(0f,2f,-10f);
	[SerializeField] float distanceDamp = 10f;
	[SerializeField] float rotationalDamp = 10f;
	Transform myT;
	void Awake()
	{
		myT = transform;
	}
	void LateUpdate()
	{
		Vector3 toPos = target.position +(target.rotation*defaultDistance);
		Vector3 curPos = Vector3.Lerp(myT.position,toPos,distanceDamp*Time.deltaTime);
		myT.position = curPos;

		Quaternion toRot = Quaternion.LookRotation(target.position-myT.position, target.up);
		Quaternion curRot = Quaternion.Slerp(myT.rotation,toRot,rotationalDamp*Time.deltaTime);
		myT.rotation = curRot;
	}
}
