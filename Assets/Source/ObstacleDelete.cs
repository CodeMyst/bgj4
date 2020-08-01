using UnityEngine;

public class ObstacleDelete : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "obstacle")
        {
            Destroy(col.gameObject);
        }
    }
}
