using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float hp = 50;

    public float animTime = 1;
    private float currentAnimTime;

    public float moveDistance = 2;

    private Vector3 startPos;
    private Vector3 endPos;

    public virtual void Start()
    {
        startPos = transform.localPosition;
        endPos = transform.localPosition + transform.up * moveDistance;
    }

    public virtual void Update()
    {
        if (transform.localPosition == endPos)
        {
            Vector3 temp = startPos;
            startPos = endPos;
            endPos = temp;
            currentAnimTime = 0f;
        }

        currentAnimTime += Time.deltaTime;
        if (currentAnimTime > animTime)
        {
            currentAnimTime = animTime;
        }

        float perc = currentAnimTime / animTime;
        perc = perc*perc*perc * (perc * (6f * perc - 15f) + 10f);
        transform.localPosition = Vector3.Lerp(startPos, endPos, perc);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            hp -= 25f;
        }

        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
