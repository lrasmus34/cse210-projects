public class Entry
{
    public string _prompt { get; set; }
    public string _response { get; set; }
    public string _date { get; set; }

    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now.ToString("MM-dd-yyyy");
    }

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }
}