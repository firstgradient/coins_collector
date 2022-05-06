using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Collected();
            Destroying();
        }
    }

    protected abstract void Collected();

    protected virtual void Destroying()
    {
        Object.Destroy(gameObject);
    }
}
