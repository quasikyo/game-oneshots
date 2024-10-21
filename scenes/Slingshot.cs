using Godot;
using System;

public partial class Slingshot : Node2D {

	private RigidPlayer Player { get; set; }

	private Line2D Line { get; set; }

	private Vector2 _start = Vector2.Zero;
	private Vector2 Start {
		get => _start;
		set {
			_start = value;
			Line?.SetPointPosition(0, value);
		}
	}

	private Vector2 _end = Vector2.Zero;
	private Vector2 End {
		get => _end;
		set {
			_end = value;
			Line?.SetPointPosition(1, value);
		}
	}

	public override void _Ready() {
		Player = GetNode<RigidPlayer>("%RigidPlayer");
		Line = GetNode<Line2D>("Line2D");
		Line.AddPoint(Vector2.Zero);
		Line.AddPoint(Vector2.Zero);
	}

	public override void _Input(InputEvent @event) {
		if (@event.IsActionPressed(Constants.Primary)) {
			Start = GetGlobalMousePosition();
			End = GetGlobalMousePosition();
		}
		if (@event.IsActionReleased(Constants.Primary)) {
			Launch();
			Reset();
		}
	}

	public override void _Process(double deltaSeconds) {
		if (Input.IsActionPressed(Constants.Primary)) {
			End = GetGlobalMousePosition();
		}
	}

	private void Reset() {
		Start = Vector2.Zero;
		End = Vector2.Zero;
	}

	private void Launch() {
		float drawnAngle = End.AngleToPoint(Start);
		float drawnMagnitutde = (End - Start).Length();
		Vector2 impulse = Vector2.FromAngle(drawnAngle) * drawnMagnitutde;
		Player.ApplyImpulse(impulse);
	}
}
