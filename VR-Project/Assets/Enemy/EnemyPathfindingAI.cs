using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfindingAI : MonoBehaviour
{
    public Transform player; // This is what our enemy will be chasing, and it can be changed inside of Unity's editor
    public float moveSpeed = 3f; // How fast our enemy moves
    public float detectionRange = 6f; // How far the enemy can detect you from
    public float stopDistance = 2f; // I was having some trouble with colliders so for now the capsule enemy just menacingly stops in front of the player

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // It will start moving once it sees you
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        // this is used for finding the direction of the player
        Vector3 direction = (player.position - transform.position).normalized;

        // this tells the enemy to start moving
        if (Vector3.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            // the aforementioned menacing stop
            Debug.Log("Enemy has reached the player!");
        }

        // this was for when we had a monster model planned for the game; it would make the monster look at the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
