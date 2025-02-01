using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _field;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _fieldRadius = 1.5f;
    [SerializeField] private float _fieldCooldown = 3f;

    private bool isFieldActive = true;
    private float cooldownTimer = 0f;

    private void Update()
    {
        MovePlayer();
        ForceField();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        transform.Translate(new Vector2(moveX, moveY));
    }

    private void ForceField()
    {
        if (!isFieldActive)
        {
            _field.SetActive(false);
            cooldownTimer += Time.deltaTime;
            
            if (cooldownTimer >= _fieldCooldown)
            {
                isFieldActive = true;
                cooldownTimer = 0f;
                _field.SetActive(true);
            }
        }

        if (isFieldActive)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _fieldRadius);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject);
                    isFieldActive = false;
                    Debug.Log("Enemy Destroyed");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isFieldActive)
        {
            Debug.Log("Game Over!");
            gameObject.SetActive(false);
        }
    }
}
