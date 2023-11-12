using UnityEngine;

public class AirBalloonCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool collidedWithButterflies = collision.CompareTag("Butterflies");
        if (collidedWithButterflies == false) return;

        Collider2D[] otherCollider = new Collider2D[1];
        int otherCollidersCount = collision.GetContacts(otherCollider);

        if (otherCollidersCount == 0) return;

        switch (otherCollider[0].name)
        {
            case "balloon":
                TriggerCollisionWithBalloon(collision);
                break;
            case "basket":
                TriggerCollisionWithBasket(collision);
                break;
        }
    }

    private void TriggerCollisionWithBalloon(Collider2D collision)
    {
        Butterflies butterflies = collision.gameObject.GetComponent<Butterflies>();

        butterflies.DisperseButterflies();
    }

    private void TriggerCollisionWithBasket(Collider2D collision)
    {
        Butterflies butterflies = collision.gameObject.GetComponent<Butterflies>();
        butterflies.CollectButterflies();
    }


}
