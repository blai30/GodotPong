using Godot;

namespace GodotPong;

public partial class Rail : Area2D
{
    [Export]
    private int _bounceDirection = 1;

    public override void _EnterTree()
    {
        AreaEntered += OnAreaEntered;
    }

    public override void _ExitTree()
    {
        AreaEntered -= OnAreaEntered;
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is not Ball ball) return;
        var direction = (ball.Direction + new Vector2(0, _bounceDirection)).Normalized();
        ball.Bounce(direction);
    }
}
