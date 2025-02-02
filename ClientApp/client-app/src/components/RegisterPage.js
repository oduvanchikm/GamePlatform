import React from 'react';
import { Link } from 'react-router-dom';
import './RegisterPage.css';

function RegisterPage() {
    return (
        <div className="register-container">
            <h1>Регистрация</h1>
            <form>
                <div className="input-group">
                    <label>Имя:</label>
                    <input type="text" placeholder="Введите ваше имя" />
                </div>
                <div className="input-group">
                    <label>Электронная почта:</label>
                    <input type="email" placeholder="Введите вашу почту" />
                </div>
                <div className="input-group">
                    <label>Пароль:</label>
                    <input type="password" placeholder="Введите пароль" />
                </div>
                <button type="submit" className="submit-button">Зарегистрироваться</button>
            </form>
            <p>
                Уже есть аккаунт? <Link to="/login">Войдите</Link>
            </p>
        </div>
    );
}

export default RegisterPage;
