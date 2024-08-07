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

	[SerializeField]
	private Color slowedColor = Color.cyan;

	private bool isDead = false;

	private bool isSlowed = false;
	private SpriteRenderer sprite;

	[SerializeField]
	private Enemy shield = null;

	// -- StartingSpeed property. References type.startingSpeed. //
	public float StartingSpeed
    {
		get { return type.startingSpeed;  }
		private set {}
    }

	public int Damage
    {
		get { return type.damage; }
		private set { }
    }

	void Start ()
	{

        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        speed = type.startingSpeed;
		health = type.startingHealth;
		sprite = GetComponent<SpriteRenderer>();
	}
	// Modified Value -> Turrets can net more money if they destroyed them. 
	public void TakeDamage (float amount, int modifiedValue = 0, float slowPct = 0.0f)
	{
		if (shield != null)
		{
			shield.TakeDamage(amount, 0, 0);
		}
		else
		{
			health -= amount;

			//healthBar.fillAmount = health / startHealth;
			if (slowPct > 0) Slow(slowPct);
			// -- Add extra money per hit -- //
			playerStats.UpdateMoney(PlayerStats.Money += (modifiedValue));

			if (health <= 0 && !isDead)
			{
				Die();
			}
		}
	}

	public void Slow (float pct)
	{
		speed = type.startingSpeed * (1f - pct);
		if (!isSlowed)
        {
			sprite.color = slowedColor;
			isSlowed = true;
        }
	}
	void Die()
	{
		isDead = true;
		playerStats.UpdateMoney(PlayerStats.Money += (type.worth));
		GameManager.Instance.EnemiesOnField-= 1;
		Destroy(gameObject);
	}

}
