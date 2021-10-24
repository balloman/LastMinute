using System.Collections.Generic;

public static class InputActions
{
    public enum Actions
    {
        Movement,
        Interact,
        PlayerTwoMovement,
        Attack
    }

    public static Dictionary<Actions, string> GetAction => new Dictionary<Actions, string>
    {
        { Actions.Movement, "Movement" },
        { Actions.Interact, "Interact" },
        { Actions.PlayerTwoMovement , "Movement1"},
        { Actions.Attack, "Attack" }
    };
}