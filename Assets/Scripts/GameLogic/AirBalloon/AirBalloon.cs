using UnityEngine;

public class AirBalloonCollider : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] otherCollider = new Collider2D[1];
        int otherCollidersCount = collision.GetContacts(otherCollider);

        if (otherCollidersCount == 0) return;

        switch (otherCollider[0].name)
        {
            case "balloon":
                TriggerCollisionWithBalloon();
                break;
            case "basket":
                TriggerCollisionWithBasket();
                break;
        }
    }

    private void TriggerCollisionWithBalloon()
    {

    }
    private void TriggerCollisionWithBasket()
    {

    }


}
