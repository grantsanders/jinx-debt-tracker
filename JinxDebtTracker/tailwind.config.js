const defaultTheme = require('tailwindcss/defaultTheme')

/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: ['**/*.{razor,html,cshtml,js}'],
  plugins: [require('@tailwindcss/typography')],
  theme: {
    extend: {
      // Add custom animations here
      colors: {
        'dark-purple': '#6a0dad'  // Custom dark purple color
      },
      animation: {
        'spin': 'spin 1s linear infinite',  // This creates the spin animation with infinite loop
      },
      keyframes: {
        spin: {
          '0%': { transform: 'rotate(0deg)' },  // Start of the animation
          '100%': { transform: 'rotate(360deg)' }  // End of the animation (full rotation)
        }
      }
    }
  }
}
