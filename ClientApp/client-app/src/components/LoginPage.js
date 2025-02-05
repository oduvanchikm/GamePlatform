import React, {useState} from 'react';
import {data, Link, useNavigate} from 'react-router-dom';
import './LoginPage.css';

function LoginPage() {
    const navigate = useNavigate();
    const [email, setEmail] = React.useState('');
    const [isLoading, setIsLoading] = useState(false);
    const [password, setPassword] = React.useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        setIsLoading(true);

        const registerData = {
            email: email,
            password: password
        };

        try {
            const response = await fetch('http://localhost:5203/api/login-page/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(registerData),
            });

            if (response.ok) {
                const data = await response.json();
                if (data.redirectTo) {
                    localStorage.setItem("fullName", data.fullName);
                    navigate(data.redirectTo);
                }
            } else {
                const error = await response.text();
                alert(error);
            }
        } catch (error) {
            console.error('Request error', error);
            alert('Login error');
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="home-container">
            <div className="auth-container">
                <div className="login-container">
                    <h1>Login</h1>
                    <form onSubmit={handleSubmit}>
                        <div className="input-group">
                            <label>Email</label>
                            <input
                                type="email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                                placeholder="Enter your email"
                                disabled={isLoading}
                            />
                        </div>
                        <div className="input-group">
                            <label>Password</label>
                            <input
                                type="password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                placeholder="Enter your password"
                                disabled={isLoading}
                            />
                        </div>
                        <button type="submit" className="submit-button">
                            {isLoading ? <span className="Loader..."></span> : "Login"}
                        </button>
                    </form>
                    <p>
                        No account? <Link to="/register">Register</Link>
                    </p>
                </div>

                <div className="info-container">
                    <div>
                        <h2>Welcome to the Game Hub!</h2>
                        <p>Explore the best games, enjoy game time.</p>
                    </div>
                </div>

                <div className="button-container">
                    <Link to="/">
                        <button className="action-button">Back</button>
                    </Link>
                </div>
            </div>
        </div>
    );
}

export default LoginPage;
