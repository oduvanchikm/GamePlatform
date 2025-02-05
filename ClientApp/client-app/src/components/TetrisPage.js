// React компонент TetrisPage.jsx
import { useEffect, useState } from 'react';
import './TetrisPage.css';

function TetrisPage() {
    const [grid, setGrid] = useState([]);

    useEffect(() => {
        fetch('http://localhost:5203/api/tetris-page/start')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Ошибка сети');
                }
                return response.json();
            })
            .then(data => {
                console.log("Ответ от сервера:", data);
                setGrid(data.grid);
            })
            .catch(error => {
                console.error("Ошибка получения данных:", error);
            });
    }, []);

    return (
        <div className="container">
            <h1>Tetris</h1>
            <div className="tetris-board">
                {grid.length > 0 ? (
                    grid.map((row, rowIndex) => (
                        <div key={rowIndex} className="tetris-row">
                            {row.map((cell, cellIndex) => (
                                <div
                                    key={cellIndex}
                                    className={`tetris-cell ${cell === 0 ? 'empty' : (cell === 1 ? 'filled' : 'tetromino')}`}
                                />
                            ))}
                        </div>
                    ))
                ) : (
                    <p>Загрузка игрового поля...</p>
                )}
            </div>
        </div>
    );
}

export default TetrisPage;