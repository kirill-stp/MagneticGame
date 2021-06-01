using UnityEngine;

public class BallMagnet : Magnet
{
    protected override void ApplyForce(Ball ball)
    {
        var direction = transform.position - ball.transform.position;
        var distance = direction.magnitude;
        var force = direction.normalized * forceValue / distance;
        ball.AddForce(force * Time.deltaTime * 1e2f);
    }
}
