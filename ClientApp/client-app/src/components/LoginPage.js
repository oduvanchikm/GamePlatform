import React from 'react';
import { Link } from 'react-router-dom';
import './LoginPage.css';

function LoginPage() {
    return (
        <div className="login-container">
            <h1>Авторизация</h1>
            <form>
                <div className="input-group">
                    <label>Электронная почта:</label>
                    <input type="email" placeholder="Введите вашу почту" />
                </div>
                <div className="input-group">
                    <label>Пароль:</label>
                    <input type="password" placeholder="Введите пароль" />
                </div>
                <button type="submit" className="submit-button">Войти</button>
            </form>
            <p>
                Нет аккаунта? <Link to="/register">Зарегистрируйтесь</Link>
            </p>
        </div>
    );
}

export default LoginPage;
