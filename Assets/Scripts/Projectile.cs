using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Transform target;

    public void Setup(Transform target)
    {
        movement2D = GetComponent<Movement2D>();
        this.target = target;
    }

    private void Update()
    {
        if ( target != null )
        {
            Vector3 direction = (target.position-transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collistion)
    {
        if ( !collistion.CompareTag("Enemy") ) return;
        if ( collistion.transform != target ) return;

        collistion.GetComponent<Enemy>().OnDie();
        Destroy(gameObject);
    }
}
