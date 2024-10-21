using Godot;
using Godot.Collections;

public partial class Accelerator : PointLight2D {

	[Export]
	public int Force { get; set; } = 5000;
	// private float Angle { get; set; }

	private Area2D Zone { get; set; }

	public override void _Ready() {
		Zone = GetNode<Area2D>("Area2D");
		Zone.Monitoring = true;
	}

	public override void _PhysicsProcess(double deltaSeconds) {
		Vector2 force = Vector2.FromAngle(Rotation) * Force;
		GD.Print(force);
		Array<Node2D> bodies = Zone.GetOverlappingBodies();
		foreach (Node2D body in bodies) {
			if (body is not RigidBody2D) {
				continue;
			}

			(body as RigidBody2D).ApplyForce(force);
		}
	}
}
