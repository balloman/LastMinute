using System.Collections.Generic;

public static class Tags
{
    //Put the tags we use here
    public enum Tag
    {
        Body,
        Wisp,
        Interactable,
        Enemy,
        Box
    }

    //Map the tags to their strings here
    public static Dictionary<Tag, string> GetTag => new Dictionary<Tag, string>
    {
        { Tag.Body, "Body" },
        { Tag.Wisp, "Wisp" },
        { Tag.Interactable, "Interactable" },
        { Tag.Enemy, "Enemy" },
        { Tag.Box , "Box"}
    };
}