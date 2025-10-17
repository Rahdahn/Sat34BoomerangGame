using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] private float  speed = 10f;

    private Transform player;
    private Vector3 targetPos;
    private bool returning = false;

    public void Init(Transform playerTransform, Vector3 target)
    {
        player = playerTransform;
        targetPos = target;
    }

    void Update()
    {
        if (!returning)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPos) < 0.1f)
                returning = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, player.position) < 0.3f)
            {
                player.GetComponent<PlayerController>().BackBoomerang();
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(1);
            }
        }
    }

}
