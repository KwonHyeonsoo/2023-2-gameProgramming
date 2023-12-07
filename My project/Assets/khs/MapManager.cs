using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapManager : MonoBehaviour
{
	private float countTime = 0;
	public Vector3 position = new Vector3(10, 0, 0);
	
	private Vector3 _generatePos = new Vector3(0, 0, 20.5f);

	[SerializeField] private float makeTime = 5f;
	[SerializeField] private List< GameObject> _mapPrefabList;
	[SerializeField] private MonsterManager MonsterManager;
	[SerializeField] private PotionManager PotionManager;

	private Vector3 cubeSize;
	private Vector3 PlayerPos = Vector3.zero;
	

	public void Init()
	{
	}

	private void Awake()
	{
		cubeSize = getSizeCube();
		staticValues.CubeSize = cubeSize;
		GenerateNavmesh();
	}

	private void GenerateNavmesh()
	{
		float bol = Random.value;
		for (int i = 0; i < _mapPrefabList.Count; i++)
		{
			_generatePos = PlayerPos +  new Vector3( (cubeSize.x*2*i)-cubeSize.x , 0, cubeSize.z*5/4);
			GameObject obj = Instantiate(_mapPrefabList[i], _generatePos, Quaternion.identity, transform);

			//if (bol > 0.5f) 
				MonsterManager.monsterSpawn(_generatePos);
			//else if (i > 0 && bol > 0.5)
			{
				//else PotionManager.potionSpawn(_generatePos, (int)cubeSize.x, (int)cubeSize.y);
			}

		}
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

	Vector3 getSizeCube()
    {
		Vector3 size;
		size = _mapPrefabList[0].transform.localScale;
		//Debug.Log("size: " + size);
		return size;
    }

	public void setPlayerPosition(Vector3 position)
    {
		//Debug.Log("cube pos: " + position);
		PlayerPos = position;
    }
}