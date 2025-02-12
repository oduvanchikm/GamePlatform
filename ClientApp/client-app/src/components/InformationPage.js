import React, {useEffect, useState} from 'react';

const InformationPage = () => {
    const [profile, setProfile] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProfile = async () => {
            try {
                const response = await fetch('http://localhost:5203/api/information-page/information', {
                    method: "GET",
                    headers: {
                        "Content-Type": "application/json"
                    },
                });

                if (!response.ok) {
                    throw new Error(`Ошибка: ${response.statusText}`);
                }

                const data = await response.json();
                setProfile(data);

            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        void fetchProfile();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <div className="home-container">
            <div className="profile-card">
                <h2 className="profile-title">User's Profile</h2>
                <div className="profile-details">
                    <p><strong>Name:</strong> {profile.name}</p>
                    <p><strong>Surname:</strong> {profile.surname}</p>
                    <p><strong>Date of Birth:</strong> {profile.dateOfBirth}</p>
                    <p><strong>Gender:</strong> {profile.gender}</p>
                    <p><strong>Email:</strong> {profile.email}</p>
                </div>
            </div>
        </div>
    );
};

export default InformationPage;
