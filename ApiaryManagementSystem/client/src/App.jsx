import './App.css'
import Header from './components/header/Header'
import { AuthContextProvider } from './contexts/AuthContext'

function App() {
  return (
    <AuthContextProvider>
      <Header />
    </AuthContextProvider>
  )
}

export default App
