using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;
	private Waypoints _pathToFollow;
	private Enemy enemy;
	public bool HasSetPath = false;

	void Start()
	{
		enemy = GetComponent<Enemy>();
	}

    void Update()
	{
		if (HasSetPath)
		{
			Vector3 dir = target.position - transform.position;
			transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

			if (Vector3.Distance(transform.position, target.position) <= 0.4f)
			{
				GetNextWaypoint();
			}

			enemy.speed = enemy.startSpeed;
		}
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= _pathToFollow.Points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = _pathToFollow.Points[wavepointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
	public void SetPath(Waypoints waypoints)
    {
		_pathToFollow = waypoints;
		target = _pathToFollow.Points[0];
		HasSetPath = true;
	}

}
