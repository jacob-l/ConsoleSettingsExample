public class AppSettings
{
    private const string AppName = "MyConsoleApp";

    private static string _settingsPath = GetSettingsPath();

    private static AppSettings? _instance;

    private Dictionary<string, string> _settingsDicitonary = new Dictionary<string, string>();

    private AppSettings()
    {
        if (System.IO.File.Exists(_settingsPath))
        {
            _settingsDicitonary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(_settingsPath));
        }
        else
        {
            _settingsDicitonary = new Dictionary<string, string>();
        }
    }

    private static string GetSettingsPath()
    {
        var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var fullPath = Path.Combine(appDataFolder, AppName, "app.json");
        //Console.WriteLine(fullPath);
        return fullPath;
    }

    public static AppSettings Instance
    {
        get
        {
            _instance ??= new AppSettings();

            return _instance;
        }
    }

    public void SaveValue(string name, string value)
    {
        _settingsDicitonary[name] = value;
        Directory.CreateDirectory(Path.GetDirectoryName(_settingsPath));
        System.IO.File.WriteAllText(_settingsPath, System.Text.Json.JsonSerializer.Serialize(_settingsDicitonary));
    }

    public string? GetValue(string name)
    {
        if (_settingsDicitonary.ContainsKey(name))
        {
            return _settingsDicitonary[name];
        }

        return null;
    }
}