using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;
    public GameObject Player;
    //public GameObject enemy;
	Animator anim;
	GameManager gameManager;
	CapsuleCollider collider;
	public DoorTrigger dt;
	public bool IsDead;
	public int damage;
	int health=100;
	int count=0;
	void Start()
	{
		anim = GetComponent<Animator>();
		collider = GetComponent<CapsuleCollider>();
		gameManager = Player.GetComponent<GameManager>();
		target = Player.transform;
		agent = GetComponent<NavMeshAgent>();
		IsDead = false;
	}

	void Update ()
	{
		if (!IsDead && !gameManager.IsDead)
		{
			float distance = Vector3.Distance(target.position, transform.position);
		
			if (distance <= lookRadius)
			{
				agent.SetDestination(target.position);
				anim.SetBool("IsWalking",true);
				anim.SetBool("IsAttacking",false);
				FaceTarget();
				if (distance <= agent.stoppingDistance)
				{
					count++;
					if (count != 100) 
					{
						anim.SetBool("IsWalking",false);
						anim.SetBool("IsAttacking",false);
					}
					if (count==100) Attack();
				}
			}
			else 
			{
				anim.SetBool("IsWalking",false);
				anim.SetBool("IsAttacking",false);
			}
		}
		if (gameManager.IsDead)
		{
			anim.SetBool("IsWalking",false);
			anim.SetBool("IsAttacking",false);
		}
		if (IsDead)
		{
			collider.enabled = false;
			agent.enabled = false;
		}
	}

	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			dt.EnemyCount--;
			IsDead = true;
			anim.SetBool("IsWalking",false);
			anim.SetBool("IsAttacking",false);
			anim.SetBool("IsDead",true);
			if (Random.Range(0,10) >= 7) gameManager.health += 20; //by chance player might get 20 hp
		}
	}

	void Attack()
	{
		count = 0;
		anim.SetBool("IsWalking",false);
		anim.SetBool("IsAttacking",true);
		gameManager.TakeDamage(damage);
	}
}