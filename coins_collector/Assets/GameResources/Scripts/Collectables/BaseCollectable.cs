using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Collected();
            Burst();
        }
    }

    protected abstract void Collected();

    protected virtual void Burst()
    {
        Object.Destroy(gameObject);
    }
}
