public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one mistake I made today, and what did I learn from it?",
        "What scripture or spiritual thought impacted me today?",
    };

    public void WriteEntry()
    {
        Random promp = new Random();
        string prompt = _prompts[promp.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry log = new Entry(prompt, response);
        _entries.Add(log);
        Console.WriteLine("Entry recorded.");
    }

    public void Display()
    {
        Console.WriteLine("\nJournal Entries:");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToCsv(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            //Saving as csv file
            writer.WriteLine("Date,Prompt,Response"); 

            foreach (Entry entry in _entries)
            {
                string savePrompt = entry._Prompt.Replace("\"", "\"\"");
                string saveResponse = entry._Response.Replace("\"", "\"\"");
            
                writer.WriteLine($"\"{entry._Date}\",\"{savePrompt}\",\"{saveResponse}\"");
            }
        }
        Console.WriteLine("Journal saved as a CSV.");
    }

    public void LoadFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        for (int i = 0; i < lines.Length; i += 4)
        {
            string date = lines[i];
            string prompt = lines[i + 1];
            string response = lines[i + 2];
            _entries.Add(new Entry(prompt, response) { _Date = date });
        }
        Console.WriteLine("Journal loaded.");
    }
}
