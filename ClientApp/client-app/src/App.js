import React from 'react';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import MainPage from './components/MainPage';
import RegisterPage from './components/RegisterPage';
import LoginPage from './components/LoginPage';
import PersonalPage from "./components/PersonalPage";
import './App.css';
import TetrisPage from "./components/TetrisPage";
import InformationPage from "./components/InformationPage";
import ChessPage from "./components/ChessPage";


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
                <Route path="/tetris/rotate" element={<TetrisPage/>}/>
                <Route path="/tetris/down" element={<TetrisPage/>}/>
                <Route path="/information" element={<InformationPage/>}/>
                <Route path="/chess" element={<ChessPage/>}/>
            </Routes>
        </Router>
    );
}

export default App;
