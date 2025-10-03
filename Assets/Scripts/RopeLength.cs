using GogoGaga.OptimizedRopesAndCables;
using UnityEngine;

public class RopeLength : MonoBehaviour
{
    public Rope rope;
    public CannonBall ball;
    public BallGravity ballG;
    public float lengthRate = 4.0f;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if (ball.inAir)
            rope.ropeLength += Time.deltaTime * lengthRate ;

        if(Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            Debug.Log("ball hit");
            ball.inAir = false;
            rope.ropeLength = 2;
            ballG.enabled = false;
        }


    }

}
