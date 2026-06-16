using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public void Throw()
    {
        Vector2 randomCircle = Random.insideUnitCircle * 3f;
        float randomUpForce = Random.Range(3f, 6f);
        Vector3 launchVelocity = new Vector3(randomCircle.x, randomUpForce, randomCircle.y);
        rb.linearVelocity = launchVelocity;
    }

    void Update()
    {
        transform.Rotate(180f * Time.deltaTime * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            Destroy(gameObject);
        }
    }
}
