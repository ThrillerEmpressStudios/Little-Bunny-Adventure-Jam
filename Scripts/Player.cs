using Godot;
using System;

public class Player : KinematicBody2D
{
    Vector2 motion = new Vector2();
    Vector2 up = new Vector2(0, -1);
    const int SPEED = 95, GRAVITY = 20, JUMP = -350;

    public override void _PhysicsProcess(float delta)
    {
        motion.y += GRAVITY;

        if (Input.IsActionPressed("right"))
        {
            motion.x = SPEED;
        }
        else if (Input.IsActionPressed("left"))
        {
            motion.x = -SPEED;
        }
        else
        {
            motion.x = 0;
        }

        if (IsOnFloor())
        {
            if (Input.IsActionPressed("jump"))
            {
                motion.y = JUMP;
            }
        }

        motion = MoveAndSlide(motion, up);
    }
}