using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed = 1f; 
    protected Transform _target; 
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    private void Update()
    {
        if (_target != null)
        {
            MoveTowards(_target.position);
        }
    }
    
    public void MoveTowards(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}