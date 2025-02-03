import React from 'react';
import { Link } from 'react-router-dom';
import './LoginPage.css';

function LoginPage() {
    return (
        <div className="login-container">
            <h1>Login</h1>
            <form>
                <div className="input-group">
                    <label>Email:</label>
                    <input type="email" placeholder="Enter your email" />
                </div>
                <div className="input-group">
                    <label>Password:</label>
                    <input type="password" placeholder="Enter your password" />
                </div>
                <button type="submit" className="submit-button">Login</button>
            </form>
            <p>
                No account? <Link to="/register">Register</Link>
            </p>
        </div>
    );
}

export default LoginPage;
