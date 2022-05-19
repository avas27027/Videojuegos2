
using UnityEngine;
using UnityEngine.UI;

public class FireballController : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;

    private Vector3 mDirection;
    private float mTimer = 0f;

    private void Start()
    {
        HeroController mHeroController = GameManager.GetInstance().hero.GetComponent<HeroController>();
        mDirection = mHeroController.GetDirection();
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * mDirection;

        mTimer += Time.deltaTime;
        if (mTimer > timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
