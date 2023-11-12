using UnityEngine;
using DG.Tweening;

public class Butterflies : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _butterflyVisual;

    void OnDestroy()
    {
        DOTween.Kill(this);
    }


    public void CollectButterflies()
    {
        DisableCollider();
        // turn SpriteRenderer to green the turn off after 1 second
        _butterflyVisual.color = Color.green;

        DOVirtual.DelayedCall(1f, () =>
        {
            Destroy(gameObject);
        });
    }

    public void DisperseButterflies()
    {
        DisableCollider();

        _butterflyVisual.color = Color.red;

        DOVirtual.DelayedCall(1f, () =>
        {
            Destroy(gameObject);
        });
    }


    private void DisableCollider()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

}
