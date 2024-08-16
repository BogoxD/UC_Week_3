using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    public string vurnerableProjectile;
    public float enemySpeed = 5f;
    public float attackRange = 2f;
    public int maxHp = 100;

    private int currentHp;
    private Vector3 offset = Vector3.forward;

    private void Start()
    {
        //set variables and references
        currentHp = maxHp;
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Update()
    {
        //check if in attack range
        if (attackRange >= Vector3.Distance(transform.position, player.position))
            //move towards the player
            AttackPlayer();
        else
            Wander();
    }
    private void AttackPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position + offset, enemySpeed * Time.deltaTime);
        transform.LookAt(player.position);
    }
    private void Wander()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(vurnerableProjectile) && vurnerableProjectile != null)
        {
            TakeDamage(50);
        }
    }
    public void TakeDamage(int ammount)
    {
        currentHp -= ammount;

        if (currentHp <= 0)
            gameObject.SetActive(false);
    }
}
