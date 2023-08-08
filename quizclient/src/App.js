import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Login from './components/Login';
import Kviz from './components/Kviz';
import Rezultat from './components/Rezultat';
import Layout from './components/Layout';
import Avtentikacija from './components/Avtentikacija';
function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login/>}/>
        <Route path="/" element={<Avtentikacija/>}>
        <Route path="/" element={<Layout/>}>
        <Route path="/kviz" element={<Kviz/>}/>
        <Route path="/rezultat" element={<Rezultat/>}/>
        </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
