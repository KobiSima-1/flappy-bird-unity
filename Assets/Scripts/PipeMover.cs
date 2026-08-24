using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
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