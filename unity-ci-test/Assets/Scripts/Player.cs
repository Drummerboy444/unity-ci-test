using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;

    public void Move(Vector3 direction)
    {
        if (direction.Equals(Vector3.zero))
        {
            return;
        }

        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
