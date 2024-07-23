using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


	[HideInInspector]
	public float speed;
	
    PlayerStats playerStats;
	private float health;
	//public GameObject deathEffect;

	[Header("Unity Stuff")]
	//public Image healthBar;
	[Header("Enemy Properties")]
    [Tooltip("A reference to an enemy type (ScriptableObjects/Enemies).")]
	public EnemyType type;

	private bool isDead = false;

	// -- StartingSpeed property. References type.startingSpeed. //
	public float StartingSpeed
    {
		get { return type.startingSpeed;  }
		private set {}
    }

	void Start ()
	{

        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        speed = type.startingSpeed;
		health = type.startingHealth;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;

		//healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = type.startingSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;
        //UPDATE MONEY ON DEATH
        playerStats.updateMoney(PlayerStats.Money += type.worth);
        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

}
