using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;
	private Waypoints _pathToFollow;

	private Enemy enemy;
	private EnemyAnimation animController;


	private bool hasSetPath = false;

	void Start()
	{
		enemy = GetComponent<Enemy>();
		animController = GetComponent<EnemyAnimation>();
	}

    void Update()
	{
		if (hasSetPath)
		{
			Vector2 dir = target.position - transform.position;
			transform.Translate(enemy.speed * Time.deltaTime * dir.normalized, Space.World);

			if (Vector2.Distance(transform.position, target.position) <= 0.4f)
			{
				GetNextWaypoint();
			}
			//enemy.speed = enemy.StartingSpeed;
			// Run appropiate animations if it exists on enemy: 
			if (animController != null)
			{
				animController.SetRunningAnimations(dir);
			}
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
        HealthManager health = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthManager>();
        health.TakeDamage(((float)enemy.Damage / PlayerStats.maxLives) * 100);
		Debug.Log(((float)enemy.Damage / PlayerStats.Lives) * 100);
        PlayerStats.Lives-= enemy.Damage;
		GameManager.Instance.EnemiesOnField--;
		Destroy(gameObject);
	}
	public void SetPath(Waypoints waypoints)
    {
		_pathToFollow = waypoints;
		target = _pathToFollow.Points[0];
		hasSetPath = true;
	}

}
