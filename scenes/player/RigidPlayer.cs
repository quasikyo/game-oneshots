using Godot;

public partial class RigidPlayer : RigidBody2D {

	[Export]
	public float MoveSpeed { get; set; } = 1000f;

	[Export]
	public float HorizontalInput { get; set; } = 0f;
	public Vector2 horizontalForce = Vector2.Zero;

	public override void _Ready() {
	}

	public override void _Input(InputEvent @event) {
		// GD.Print("---");
		// GD.Print(@event.IsAction("left")); // held
		// GD.Print(@event.IsActionPressed("left")); // just pressed
		// GD.Print(@event.IsActionReleased("left"));
	}

	public override void _PhysicsProcess(double delta) {
		// HorizontalInput = Input.GetAxis("ui_left", "ui_right");
		// horizontalForce.X = HorizontalInput * MoveSpeed;
		// ApplyCentralForce(horizontalForce);
	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state) {
		// HorizontalInput = Input.GetAxis("ui_left", "ui_right");
		// horizontalForce.X = HorizontalInput * MoveSpeed;
		// ApplyCentralForce(horizontalForce);
		// state.Add
	}
}
