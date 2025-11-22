using Microsoft.JSInterop;

namespace jinx_debt_tracker.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    private bool _isDarkMode = false;
    private bool _isInitialized = false;

    public event Action? OnThemeChanged;
    
    public bool IsDarkMode
    {
        get => _isDarkMode;
        private set
        {
            if (_isDarkMode != value)
            {
                _isDarkMode = value;
                OnThemeChanged?.Invoke();
            }
        }
    }

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        if (_isInitialized) return;
        
        try
        {
            // Check system preference
            var prefersDark = await _jsRuntime.InvokeAsync<bool>("theme.getSystemPreference");
            
            // Check if user has a saved preference
            var savedTheme = await _jsRuntime.InvokeAsync<string>("theme.getSavedTheme");
            
            if (string.IsNullOrEmpty(savedTheme))
            {
                // Use system preference
                IsDarkMode = prefersDark;
            }
            else
            {
                IsDarkMode = savedTheme == "dark";
            }
            
            await ApplyThemeAsync();
            _isInitialized = true;
        }
        catch
        {
            // Fallback to light mode if JS is not available
            IsDarkMode = false;
            _isInitialized = true;
        }
    }

    public async Task ToggleThemeAsync()
    {
        IsDarkMode = !IsDarkMode;
        await ApplyThemeAsync();
        await _jsRuntime.InvokeVoidAsync("theme.setTheme", IsDarkMode ? "dark" : "light");
    }

    private async Task ApplyThemeAsync()
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("theme.applyTheme", IsDarkMode);
        }
        catch
        {
            // Ignore if JS is not available
        }
    }
}

