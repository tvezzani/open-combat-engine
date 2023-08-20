using Godot;
using System;

public partial class CollisionDamage : Node
{
    [Export]
    public float damage = 10.0f;

    [Export]
    public float knockback = 100.0f;

    public void BodyEntered(Node2D other)
    {
        KinematicArea2D parent = this.GetParent() as KinematicArea2D;
        (other as Knockbackable)
            .GetKnockbackForce()
            .ApplyForce(
                GodotSteeringAI.GSAIUtils.ToVector3(knockback * parent.LinearVelocity.Normalized())
            );

        foreach (Health health in OpenTDE.Utils.GetChildrenOfType<Health>(other))
        {
            health.Damage(damage);
        }
    }
}
