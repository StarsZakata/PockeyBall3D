using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField] private Segment SegmentTempate;
	[SerializeField] private Block Block;
	[SerializeField] private Finish FinishTemplate;

	[SerializeField] private int TowerSize;

	private void Start()	{
		BuildTower();
	}
	private void BuildTower() {
		GameObject currentpoint = gameObject;
		for (int i = 0; i < TowerSize; i++) {
			currentpoint = BuildSegment(currentpoint, SegmentTempate.gameObject);
			currentpoint = BuildSegment(currentpoint, Block.gameObject);
		}
		BuildSegment(currentpoint, FinishTemplate.gameObject);
	}
	private GameObject BuildSegment(GameObject currentSegment, GameObject nextSegment) {
		return Instantiate(nextSegment, GetBuildPoint(currentSegment.transform, nextSegment.transform), Quaternion.identity, transform);
	}

	private Vector3 GetBuildPoint(Transform currentSegment, Transform nextSegment) {
		return new Vector3(transform.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + nextSegment.localScale.y / 2, transform.position.z);
	}
}
