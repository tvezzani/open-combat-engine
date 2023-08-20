using Godot;
using GodotSteeringAI;

public class UsableKnockback
{
    public static void ApplyKnockbackAfterUse(Usable usable, Knockbackable knockbackable)
    {
        usable.OnFire += (float direction) =>
        {
            Vector3 pushbackDirection = GSAIUtils.ToVector3(
                new Vector2(1.0f, 0.0f).Rotated(direction + Mathf.Pi)
            );
            knockbackable.GetKnockbackForce().ApplyForce(100.0f * pushbackDirection);
        };
    }
}