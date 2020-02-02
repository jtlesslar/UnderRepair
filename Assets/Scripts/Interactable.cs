using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1.5f;
    public Transform interactionTransform;


    public virtual void Interact(GameObject player)
    {
        //Debug.Log("Interacting with " + transform.name);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    if (interactionTransform == null)
    //        interactionTransform = transform;

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(interactionTransform.position, radius);
    //}
}
