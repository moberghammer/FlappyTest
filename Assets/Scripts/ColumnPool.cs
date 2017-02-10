using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	public int columnPoolSize = 5;
	public GameObject columnPrefab;
	public float spawnRate = 4f;
	public float columnMin = -1f;
	public float columnMax = 3.5f;
	
	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
	private float timeSinceLastSpawned = 0f;
	private float spawnXPosition = 10f;
	private int currentColumnIndex = 0; 
	
	// Use this for initialization
	void Start () {
		columns = new GameObject[columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++) {
			columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);	
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;
		if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0;
			float spawnYPosition = Random.Range(columnMin, columnMax);
			columns[currentColumnIndex].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentColumnIndex++;
			if (currentColumnIndex >= columnPoolSize) {
				currentColumnIndex = 0;
			}
		}
	}
}
