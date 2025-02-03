import React, {useEffect, useState} from 'react';
import { Link } from 'react-router-dom';
import './MainPage.css'; 

function MainPage() {
    const [message, setMessage] = useState('');

    useEffect(() => {
        fetch('http://localhost:5203/api/main-page')
            .then(response => response.json())
            .then(data => {
                setMessage(data.message); 
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    }, []);
    
    return (
        <div className="home-container">
            <h1 className="site-title">{message || "Welcome to the world of exciting games!"}</h1>
            <p className="site-description">
                The real adventure begins here! Our website offers you a collection of games that you can choose and
                enjoy right now.
                Whether you are looking for an exciting strategic experience or just want to relax, we have everything
                for everyone!
                Choose a game and start your journey. Good luck and have a nice game!
            </p>

            <div className="game-selection-container">
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Стратегия" className="game-image"/>
                    <div className="game-title">Strategy</div>
                    <p>Развивайте свою империю, стройте армии и покоряйте мир!</p>
                </div>
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Головоломка" className="game-image"/>
                    <div className="game-title">Puzzles</div>
                    <p>Решите самые сложные загадки и прокачайте свои умственные способности.</p>
                </div>
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Гонки" className="game-image"/>
                    <div className="game-title">Races</div>
                    <p>Скорость, адреналин и сражения на трассе. Почувствуйте себя чемпионом!</p>
                </div>
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Приключения" className="game-image"/>
                    <div className="game-title">Приключения</div>
                    <p>Погрузитесь в захватывающие приключения и путешествуйте по удивительным мирам!</p>
                </div>
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Аркада" className="game-image"/>
                    <div className="game-title">Аркады</div>
                    <p>Классика жанра — быстрые и увлекательные игры, которые поднимут настроение.</p>
                </div>
                <div className="game-card">
                    <img src="/images/checkers.png" alt="PvP" className="game-image"/>
                    <div className="game-title">PvP игры</div>
                    <p>Сразитесь с друзьями или игроками со всего мира в настоящих битвах!</p>
                </div>
            </div>

            <div className="button-container">
                <Link to="/register">
                    <button className="action-button">Sign Up</button>
                </Link>
                <Link to="/login">
                    <button className="action-button">Login</button>
                </Link>
            </div>
        </div>
    );
}

export default MainPage;
