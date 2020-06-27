using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour {
	public Transform _target;
	public Vector3 _initialPos;
	float crash_;
	void Start () {
		_target = GetComponent<Transform>();
		_initialPos = _target.localPosition;
	}
	float _pendingShakeDuration = 0f;
	public void Shake(float duration,float crash)
	{
		crash_=crash;
		if(duration > 0)
		{
			_pendingShakeDuration +=duration;
		}
	}
	bool isShaking = false;
	void Update () {
		if(_pendingShakeDuration > 0 && !isShaking)
		{
			StartCoroutine(DoShake());
		}
	}
	IEnumerator DoShake()
	{
		isShaking = true;
		var startTime = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup <startTime + _pendingShakeDuration)
		{
				_initialPos = _target.localPosition;
			var randomPoint = new Vector3(Random.Range(_initialPos.x-crash_,_initialPos.x+crash_),Random.Range(_initialPos.y-crash_,_initialPos.y+crash_),_initialPos.z);
			_target.localPosition = randomPoint;
			yield return null;
		}
		_pendingShakeDuration = 0f;
		_target.localPosition = _initialPos;
		isShaking = false;
	}
}
