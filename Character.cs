using Godot;
using System;

public partial class Character : CharacterBody2D
{
	private Vector2 _velocity = new Vector2();

	private AbilityController _abilityController;

	[Export] private float _speed = 200;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this._abilityController = GetTree().Root.GetNode<Node2D>("Level").GetNode<AbilityController>("AbilityController");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.HandleSkills();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		this.HandleMovement();

		this.Velocity = this._velocity * this._speed;
		this.MoveAndSlide();
	}

	public void HandleMovement()
	{
		if(Input.IsActionPressed("character_up"))
		{
			this._velocity.Y = -1;
		}

		if (Input.IsActionPressed("character_down"))
		{
			this._velocity.Y = 1;
		}

		if (Input.IsActionPressed("character_right"))
		{
			this._velocity.X = 1;
		}

		if (Input.IsActionPressed("character_left"))
		{
			this._velocity.X = -1;
		}
	}

	public void HandleSkills()
	{
		if(Input.IsActionJustPressed("ability_1"))
		{
			this._abilityController.UseAbility(Skills.Sweep);
		}

        if (Input.IsActionJustPressed("ability_2"))
        {
            this._abilityController.UseAbility(Skills.Fireball);
        }

        if (Input.IsActionJustPressed("ability_3"))
        {
            this._abilityController.UseAbility(Skills.Dash);
        }
    }
}
