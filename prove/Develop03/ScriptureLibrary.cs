using System;
using System.Collections.Generic;

public static class ScriptureLibrary
{
    private static List<Scripture> _scriptures = new List<Scripture>
    {
        new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding."
        ),
        new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ),
        new Scripture(
            new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy."
        ),
        new Scripture(
            new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God."
        )
    };

    public static Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}