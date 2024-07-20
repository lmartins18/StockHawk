import { createContext } from 'react'

const defaultValue = {
  currentTheme: 'light',
  changeCurrentTheme: (_newTheme: 'light' | 'dark') => {},
}

const ThemeContext = createContext(defaultValue)
export default ThemeContext