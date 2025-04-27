using Godot;
using System;

public partial class GameSpace : CanvasLayer
{
	private int secondsLeft;
	private float timeAccumulator = 0;
	[Export] private NodePath ProblemContPath;
	[Export] private NodePath TimerLabelPath;
	[Export] private NodePath TimerNodePath;

	[Export] private NodePath Player1NodePath;
	[Export] private NodePath Player2NodePath;
	[Export] private NodePath Player3NodePath;
	[Export] private NodePath Player4NodePath;
	

	[Signal] public delegate void TimerFinishedEventHandler();
	[Signal] public delegate void AnswerChosenEventHandler(char button);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		var texturePath= "res://problems/1.png";
		var texture2d = (Texture2D) GD.Load(texturePath);
		GetNode<TextureRect>(ProblemContPath).Texture = texture2d;

		secondsLeft = 15;
		GetNode<Label>(TimerLabelPath).Text = timerToString();

		GetNode<Timer>(TimerNodePath).Connect("timeout", new Callable(this, nameof(_on_Timer_timeout)));
		GetNode<Timer>(TimerNodePath).Start();

        GetNode<Player>(Player1NodePath).AnswerChosen += acceptAnswer;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}

	private void _on_Timer_timeout() {
		if (secondsLeft > 0) {
			secondsLeft--;
			GetNode<Label>(TimerLabelPath).Text = timerToString();
		} else {
			ResetTimer(15);
			EmitSignal(nameof(TimerFinishedEventHandler));
			// GD.Print("Timer finished!");
		}
	}

	public void ResetTimer(int newTime = 15) {
		GetNode<Timer>(TimerNodePath).Stop();
		secondsLeft = newTime;
		GetNode<Label>(TimerLabelPath).Text = timerToString();
		GetNode<Timer>(TimerNodePath).Start();
	}

	private String timerToString() {
		return $"{00}:{secondsLeft:D2}";
	}

	private void acceptAnswer(char button){

	}
}
