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

    //Saved as a csv file
    public void SaveToCsv(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Response"); 

            foreach (Entry entry in _entries)
            {
                string savePrompt = entry._prompt.Replace("\"", "\"\"");
                string saveResponse = entry._response.Replace("\"", "\"\"");
            
                writer.WriteLine($"\"{entry._date}\",\"{savePrompt}\",\"{saveResponse}\"");
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

        // Skips header
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            // Splits by comma and handling quotes
            string[] parts = ParseCsvLine(line);

            if (parts.Length == 3)
            {
                string date = parts[0].Trim('\"');
                string prompt = parts[1].Trim('\"');
                string response = parts[2].Trim('\"');

                _entries.Add(new Entry(prompt, response) { _date = date });
            }
        }

        Console.WriteLine("Journal loaded.");
    }
    private string[] ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '\"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }

        result.Add(current);
        return result.ToArray();
    }
}