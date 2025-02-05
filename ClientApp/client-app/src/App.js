import React from 'react';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import MainPage from './components/MainPage';
import RegisterPage from './components/RegisterPage';
import LoginPage from './components/LoginPage';
import PersonalPage from "./components/PersonalPage";
import './App.css';
import TetrisPage from "./components/TetrisPage";


function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<MainPage/>}/>
                <Route path="/register" element={<RegisterPage/>}/>
                <Route path="/login" element={<LoginPage/>}/>
                {/*<Route path="/admin" element={<AdminPage />} />*/}
                <Route path="/personal" element={<PersonalPage/>}/>
                <Route path="/tetris" element={<TetrisPage/>}/>
                <Route path="/tetris/start" element={<TetrisPage/>}/>
            </Routes>
        </Router>
    );
}

export default App;
