using Godot;
using System;

public partial class AbilityController : Node2D
{
	private CanvasLayer _abilityUI;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this._abilityUI = GetTree().Root.GetNode<Node2D>("Level").GetNode<CanvasLayer>("AbilityUi");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public bool UseAbility(Skills skill)
	{
		var uiContainer = this._abilityUI.GetNode<HBoxContainer>("Container");
		switch (skill)
		{
			case Skills.Circle:
				uiContainer.GetNode<HBoxContainer>("Ability1").Modulate = Colors.Red;
				break;
			case Skills.Explosion:
				uiContainer.GetNode<HBoxContainer>("Ability2").Modulate = Colors.AliceBlue;
				break;
			case Skills.Dash:
				uiContainer.GetNode<HBoxContainer>("Ability3").Modulate = Colors.AliceBlue;
				break;
			default:
				return false;
		}

		return true;
	}
}

public enum Skills
{
	Circle,
	Explosion,
	Dash
}
