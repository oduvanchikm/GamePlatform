import React, {useState} from 'react';
import {Link, useNavigate} from 'react-router-dom';
import './RegisterPage.css';

function RegisterPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [gender, setGender] = useState('');
    const [dateOfBirth, setDateOfBirth] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setIsLoading(true);

        const registerData = {
            email: email,
            password: password,
            name: name,
            surname: surname,
            gender: gender,
            dateOfBirth: dateOfBirth,
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
                        <div className="input-group">
                            <label>Name</label>
                            <input
                                type="name"
                                value={name}
                                onChange={(e) => setName(e.target.value)}
                                placeholder="Enter your name"
                                disabled={isLoading}
                            />
                        </div>
                        <div className="input-group">
                            <label>Surname</label>
                            <input
                                type="surname"
                                value={surname}
                                onChange={(e) => setSurname(e.target.value)}
                                placeholder="Enter your surname"
                                disabled={isLoading}
                            />
                        </div>
                        <div className="input-group">
                            <label>Gender</label>
                            <select
                                value={gender}
                                onChange={(e) => setGender(e.target.value)}
                                disabled={isLoading}>
                                <option value="null">Choose a gender</option>
                                <option value="Female">Female</option>
                                <option value="Male">Male</option>
                            </select>
                        </div>
                        <div className="input-group">
                            <label>Date of Birth</label>
                            <input
                                type="date"
                                value={dateOfBirth}
                                onChange={(e) => setDateOfBirth(e.target.value)}
                                disabled={isLoading}
                            />
                        </div>
                        <button type="submit" className="submit-button">
                            {isLoading ? <span className="Loader..."></span> : "Sign up"}
                        </button>
                    </form>
                    <p>
                        Already have an account? <Link to="/login">Login</Link>
                    </p>
                </div>

                <div className="info-container">
                    <div>
                        <h2>Welcome to the Game Hub!</h2>
                        <p>Explore the best games, join the community, and start your adventure today.</p>
                    </div>
                </div>
            </div>

            <div className="button-container">
                <Link to="/">
                    <button className="action-button">Back</button>
                </Link>
            </div>
        </div>
    );
}

export default RegisterPage;
