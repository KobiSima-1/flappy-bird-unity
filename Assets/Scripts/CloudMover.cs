using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float destroyXPosition = -12f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}