window.theme = {
    getSystemPreference: function() {
        return window.matchMedia('(prefers-color-scheme: dark)').matches;
    },
    
    getSavedTheme: function() {
        return localStorage.getItem('theme');
    },
    
    setTheme: function(theme) {
        localStorage.setItem('theme', theme);
        if (theme === 'dark') {
            document.documentElement.classList.add('dark');
        } else {
            document.documentElement.classList.remove('dark');
        }
    },
    
    applyTheme: function(isDark) {
        if (isDark) {
            document.documentElement.classList.add('dark');
        } else {
            document.documentElement.classList.remove('dark');
        }
    }
};

