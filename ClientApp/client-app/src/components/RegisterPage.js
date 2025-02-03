import React, {useState} from 'react';
import {Link, useNavigate} from 'react-router-dom';
import './RegisterPage.css';

function RegisterPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setIsLoading(true);

        const registerData = {
            email: email,
            password: password,
        };

        try {
            const response = await fetch('http://localhost:5203/api/register-page/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(registerData),
            });

            if (response.ok) {
                // const result = await response.text();
                // alert(result);
                navigate('/login');
            } else {
                const error = await response.text();
                alert(error);
            }
        } catch (error) {
            console.error('Request error', error);
            alert('Registration error');
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="home-container">
            <div className="auth-container">
                <div className="register-container">
                    <h1>Sign Up</h1>
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
                            {isLoading ? <span className="loader"></span> : "Sign up"}
                        </button>
                    </form>
                    <p>
                        Already have an account? <Link to="/login">Login</Link>
                    </p>
                    <div className="button-container">
                        <Link to="/">
                            <button className="action-button">Back</button>
                        </Link>
                    </div>
                </div>

                <div className="info-container">
                    <div>
                        <h2>Welcome to the Game Hub!</h2>
                        <p>Explore the best games, join the community, and start your adventure today.</p>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default RegisterPage;
