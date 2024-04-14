using UnityEngine;

public class BallSystem : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private Rigidbody rigidbody;
    private float timer = 0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timer = 0f;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        speed = rigidbody.velocity.magnitude;
        if (speed < 0.4f && timer >= 1.9f) 
        {
            MainUI.Instance.Lose();
        }
        if (transform.position.y <= -0.1)
        {
            Destroy(this.gameObject);
            MainUI.Instance.SetDefaultBall();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (speed < 0.4f)
        {
            Destroy(this.gameObject);
            MainUI.Instance.SetDefaultBall();
        }

    }
    public void OnDestroy()
    {
        MainUI.Instance.Lose();
    }
}
