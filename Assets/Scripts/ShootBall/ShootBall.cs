
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootBall : MonoBehaviour
{
    [SerializeField] private EventSystem system;
    [SerializeField] private AudioClip audioOnshoot;
    [SerializeField] private ParticleSystem shootParticle;
    [SerializeField, Header("0 стандарт, 1 новый")] private Material[] materials;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private GameObject Cannon;
    [SerializeField] private Transform BallSpawnPos;
    [SerializeField] private float targetMax = 4f;
    [SerializeField] private float targetMin = 0f;
    private float target = 0f;
    private float speedBall = 0f;
    private int tryBall = 3;
    private GameObject nowBall;
    private bool CanShoot = false;
    private bool CanShootFree = false;
    void Start()
    {
        target = targetMax;
        MainUI.Instance.UpdateCounterBall(tryBall);
    }
    private void OnMouseEnter()
    {
        meshRenderer.material = materials[1];
    }
    private void OnMouseExit()
    {
        meshRenderer.material = materials[0];
    }

    void OnMouseOver()
    {
        if (system.IsPointerOverGameObject() || CanShootFree)
        {
            return;
        }
        if (nowBall == null && MainUI.Instance.IsWin == false)
        {
            if (Input.GetMouseButton(0))
            {
                speedBall = Mathf.MoveTowards(speedBall, target, Time.deltaTime);
                MainUI.Instance.UpdateSliderPoint(speedBall);
                CanShoot = true;

                if (speedBall >= targetMax)
                {
                    target = targetMin;
                }
                else if (speedBall <= targetMin)
                {
                    target = targetMax;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (CanShoot)
                {
                    if (tryBall <= 3 && tryBall > 0)
                    {
                        Shoot();
                        tryBall--;
                    }
                    speedBall = targetMin;
                    target = targetMax;
                    MainUI.Instance.UpdateCounterBall(tryBall);
                    MainUI.Instance.UpdateSliderPoint(0);
                }
                CanShoot = false;
            }
        }
    }
    public void Shoot()
    {
        Vector3 position = transform.position + transform.forward;
        Quaternion rotation = transform.rotation;

        GameObject ball = Instantiate(BallPrefab, BallSpawnPos.position, BallSpawnPos.rotation);
        nowBall = ball;
        MainUI.Instance.SetTarget(ball.transform);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speedBall * 10f;
        shootParticle.Play();
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayShot(audioOnshoot);
        }
    }
    public void CanShootFreeCameraLock()
    {
        CanShootFree = true;
    }
    public void CanShootFreeCameraUnLock()
    {
        CanShootFree = false;
    }
}
