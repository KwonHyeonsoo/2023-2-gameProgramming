using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapManager : MonoBehaviour
{
	private float countTime = 0;
	private float position = 40;

	[SerializeField] private float makeTime = 5f;
	[SerializeField]  private GameObject _mapPrefab;

	private Vector3 _generatePos = new Vector3(0, 0, 20.5f);

	public void Init()
	{
	}

	private void Awake()
	{
		GenerateNavmesh();
	}

	private void GenerateNavmesh()
	{
		GameObject obj = Instantiate(_mapPrefab, _generatePos, Quaternion.identity, transform);
		_generatePos += new Vector3(0, 0, 20.5f);

		NavMeshSurface[] surfaces = gameObject.GetComponentsInChildren<NavMeshSurface>();

		foreach (var s in surfaces)
		{
			s.RemoveData();
			s.BuildNavMesh();
		}

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			GenerateNavmesh();
		}

		countTime += Time.deltaTime;
		if(countTime >= makeTime)
        {

			GenerateNavmesh();
			countTime = 0;
		}
		
	}
}