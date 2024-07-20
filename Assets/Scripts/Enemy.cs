using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;
	
    PlayerStats playerStats;
    public float startHealth = 100;
	private float health;

	public int worth = 50;

	//public GameObject deathEffect;

	[Header("Unity Stuff")]
	//public Image healthBar;

	private bool isDead = false;

	void Start ()
	{

        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        speed = startSpeed;
		health = startHealth;
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
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		Debug.Log("DIE!");
		isDead = true;


        //UPDATE MONEY ON DEATH

        //PlayerStats.Money += worth;

        playerStats.updateMoney(PlayerStats.Money += worth);


        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

}
