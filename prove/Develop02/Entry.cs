public class Entry
{
    public string _Prompt { get; set; }
    public string _Response { get; set; }
    public string _Date { get; set; }

    public Entry(string prompt, string response)
    {
        _Prompt = prompt;
        _Response = response;
        _Date = DateTime.Now.ToString("MM-dd-yyyy");
    }

    public override string ToString()
    {
        return $"Date: {_Date}\nPrompt: {_Prompt}\nResponse: {_Response}\n";
    }
}