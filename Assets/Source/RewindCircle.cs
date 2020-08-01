using UnityEngine;

public class RewindCircle : MonoBehaviour
{
    public float rotation = 0;
    public float rotationSpeed = 2;

    public float spawnEvery = 2;

    private float spawnTimer;

    public Transform spawnPos;

    public GameObject[] obstaclePrefabs;

    public Player player;

    public void Start()
    {
        spawnTimer = spawnEvery;
    }

    public void LateUpdate()
    {
        if (player.dir < 0)
        {
            transform.Rotate(new Vector3(0f, 0f, rotation));
        }
        else if (player.dir > 0)
        {
            transform.Rotate(new Vector3(0f, 0f, -rotation));
        }

        rotation = rotationSpeed * Time.deltaTime;

        if (spawnTimer >= spawnEvery)
        {
            var spawned = Instantiate(obstaclePrefabs[0], spawnPos.position, Quaternion.Euler(0f, 0f, 90f), transform);

            var sp = spawned.GetComponent<SpriteRenderer>();

            spawned.transform.position -= new Vector3((sp.bounds.size.x / 2f) + 0.08f, 0);

            spawnTimer = 0;
        }

        spawnTimer += Time.deltaTime;
    }
}
