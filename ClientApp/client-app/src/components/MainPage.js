import React from 'react';
import { Link } from 'react-router-dom';
import './MainPage.css'; 

function MainPage() {
    return (
        <div className="home-container">
            <h1 className="site-title">Добро пожаловать в мир увлекательных игр!</h1>
            <p className="site-description">
                Здесь начинается настоящее приключение! Наш сайт предлагает вам коллекцию игр, которые вы можете выбрать
                и наслаждаться прямо сейчас.
                Вне зависимости от того, ищете ли вы захватывающий стратегический опыт или просто хотите расслабиться — у нас есть все для каждого!
                Выберите игру и начните свой путь. Удачи и приятной игры!
            </p>

            <div className="game-selection-container">
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Стратегия" className="game-image"/>
                    <div className="game-title">Стратегия</div>
                    <p>Развивайте свою империю, стройте армии и покоряйте мир!</p>
                </div>
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Головоломка" className="game-image"/>
                    <div className="game-title">Головоломки</div>
                    <p>Решите самые сложные загадки и прокачайте свои умственные способности.</p>
                </div>
                <div className="game-card">
                    <img src="/images/checkers.png" alt="Гонки" className="game-image"/>
                    <div className="game-title">Гонки</div>
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
                    <button className="action-button">Регистрация</button>
                </Link>
                <Link to="/login">
                    <button className="action-button">Авторизация</button>
                </Link>
            </div>
        </div>
    );
}

export default MainPage;
