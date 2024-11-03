using Godot;

namespace GodotPong;

public partial class PauseScreen : RichTextLabel
{
    public override void _Process(double delta)
    {
        if (!Input.IsActionJustPressed("ui_cancel")) return;
        if (Visible)
        {
            Hide();
            GetTree().Paused = false;
            GD.Print("Resuming game");
        }
        else
        {
            Show();
            GetTree().Paused = true;
            GD.Print("Pausing game");
        }
    }
}
