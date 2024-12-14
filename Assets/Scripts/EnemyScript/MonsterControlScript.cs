
using UnityEngine;


public class MonsterControlScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f; // Speed of the monster
    [SerializeField] private float monsterTime = 2f; // Time before behavior switches
    [SerializeField] private float chasePlayerChance = 0.5f; // Probability to chase player

    private float monsterTimer = 0f;
    private bool chasePlayer = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character");
    }

    void Update()
    {

        monsterTimer += Time.deltaTime;
        if (monsterTimer >= monsterTime)
        {
            monsterTimer = 0f;
            chasePlayer = Random.Range(0f, 1f) < chasePlayerChance;
        }


        if (chasePlayer && player != null)
        {

            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, Random.Range(-30f, 30f) * Time.deltaTime, 0);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}