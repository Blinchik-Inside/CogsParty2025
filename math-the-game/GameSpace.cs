using Godot;
using System;

public partial class GameSpace : CanvasLayer
{
	[Export] NodePath ProblemContPath;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		var texturePath= "res://problems/1.png";
		var texture2d = (Texture2D) GD.Load(texturePath);
		GetNode<TextureRect>(ProblemContPath).Texture = texture2d;
		//Print("Hello World!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}
}
