import { useEffect, useState } from 'react';
import './TetrisPage.css';

function TetrisPage() {
    const [grid, setGrid] = useState([]);
    const [isFastDrop, setIsFastDrop] = useState(false);

    const fetchGrid = async (endpoint, method = 'POST') => {
        try {
            const response = await fetch(`http://localhost:5203/api/tetris-page/${endpoint}`, { method });
            if (!response.ok) throw new Error('Ошибка сети');
            const data = await response.json();
            setGrid(data.grid);
        } catch (error) {
            console.error(`Ошибка запроса (${endpoint}):`, error);
        }
    };

    useEffect(() => {
        fetchGrid('start', 'GET').catch(console.error);
    }, []);

    useEffect(() => {
        const handleKeyDown = async (e) => {
            if (e.code === 'Space') {
                e.preventDefault();
                await fetchGrid('rotate');
            }
            if (e.code === 'ArrowDown') {
                e.preventDefault();
                setIsFastDrop(true);
            }
        };

        const handleKeyUp = (e) => {
            if (e.code === 'ArrowDown') {
                setIsFastDrop(false);
            }
        };

        window.addEventListener('keydown', handleKeyDown);
        window.addEventListener('keyup', handleKeyUp);
        return () => {
            window.removeEventListener('keydown', handleKeyDown);
            window.removeEventListener('keyup', handleKeyUp);
        };
    }, []);

    useEffect(() => {
        const intervalSpeed = isFastDrop ? 200 : 3000;

        const interval = setInterval(() => {
            fetchGrid('down').catch(console.error);
        }, intervalSpeed);

        return () => clearInterval(interval);
    }, [isFastDrop]);

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
                                    className={`tetris-cell ${cell === 0 ? 'empty' : 'filled'}`}
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
