using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	[SerializeField]
	private float startingCountdown = 2f;

	//public Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex = 0;

	[SerializeField]
	private Waypoints _waypoints;

    private void Awake()
    {
		countdown = startingCountdown;
    }

    private void Start()
    {
		GameManager.Instance.AddToWaves(waves.Length);
    }

    void Update ()
	{

		if (waveIndex == waves.Length)
		{
			this.enabled = false;
			
		}
		else if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
            countdown = 100f;//buffer so countdown wont start before last unit of wave is spawned
            return;
		}

		countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		//waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		GameManager.Instance.EnemiesOnField += wave.count;
		GameManager.Instance.CurrentWaves++;

		for (int i = 0; i < wave.count; i++)
		{
			//TODO: optimize this... (should not getComponent every in a loop!)
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;

        countdown = timeBetweenWaves;//start timer after last unit of the wave is spawned 
    }


	void SpawnEnemy (GameObject enemy)
	{
		GameObject instance = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		EnemyMovement mov = instance.GetComponent<EnemyMovement>();
		mov.SetPath(_waypoints);
		instance.SetActive(true);
	}

}
