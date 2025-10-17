using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private GameObject _boomerangPrefab;
    [SerializeField] private Transform _boomerangSpawnPoint;

    private float minY = -4.5f;
    private float maxY = 4.5f;
    private bool _hasBoomerang = true;
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && _hasBoomerang)
        {
            TrowBoomerang();
        }
    }

    private void Move()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 pos = transform.position;
        pos.y += moveY * _moveSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private void TrowBoomerang()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Instantiate(_boomerangPrefab, _boomerangSpawnPoint.position, Quaternion.identity)
            .GetComponent<Boomerang>()
            .Init(this.transform, mouseWorldPos);
        _hasBoomerang = false;
    }

    public void BackBoomerang()
    {
        _hasBoomerang = true;
    }
}
