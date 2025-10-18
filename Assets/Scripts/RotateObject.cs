using UnityEngine;

public class RotateItem : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -10));
    }
}
