using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
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
