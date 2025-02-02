import React from 'react';
import { Link } from 'react-router-dom';
import './MainPage.css'; 

function MainPage() {
    return (
        <div className="home-container">
            <h1 className="site-title">Добро пожаловать на наш сайт!</h1>
            <p className="site-description">
                Мы рады видеть вас! Нажмите одну из кнопок ниже, чтобы начать.
            </p>
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
