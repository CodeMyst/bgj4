using UnityEngine;

public class ShootingEnemy : BasicEnemy
{
    private Player player;

    public GameObject bulletPrefab;
    public float bulletSpeed = 5;
    public float bulletCooldown = 1;
    private float bulletTimer = 0;
    public Transform shootPos;

    public override void Start()
    {
        base.Start();

        player = FindObjectOfType<Player>();
    }

    public override void Update()
    {
        base.Update();

        if (bulletTimer >= bulletCooldown)
        {
            var target = player.transform.position - shootPos.position;
            target.Normalize();
            var bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
            
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position);

            bullet.GetComponent<Rigidbody2D>().velocity = target * bulletSpeed;
            bulletTimer = 0f;
        }

        bulletTimer += Time.deltaTime;
    }
}
