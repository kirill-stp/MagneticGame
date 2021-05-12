public class BallMagnetExample : MagnetExample
{
    #region Private methods

    protected override void ApplyForce(Ball ball)
    {
        var direction = transform.position - ball.transform.position;
        var distance = direction.magnitude;
        var force = direction.normalized * forceValue / distance;
        ball.AddForce(force);
    }

    #endregion
}
