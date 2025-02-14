import React, { useEffect, useState } from "react";
import { Chessboard } from "react-chessboard";
import { Chess } from "chess.js";
import "./ChessPage.css";
import { Link } from "react-router-dom";

const pieceNotation = {
    p: "",
    n: "N",
    b: "B",
    r: "R",
    q: "Q",
    k: "K"
};

const ChessPage = () => {
    const [game, setGame] = useState(new Chess());
    const [moves, setMoves] = useState([]);

    async function fetchGameState() {
        const response = await fetch("http://localhost:5203/api/chess-page/state");
        const data = await response.json();
        setGame(new Chess(data.fen));
    }

    useEffect(() => {
        void fetchGameState();
    }, []);

    async function onDrop(sourceSquare, targetSquare) {
        const response = await fetch("http://localhost:5203/api/chess-page/move", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ from: sourceSquare, to: targetSquare }),
        });

        if (response.ok) {
            const data = await response.json();
            const newGame = new Chess(data.fen);
            setGame(newGame);

            const moveObj = game.move({ from: sourceSquare, to: targetSquare, promotion: "q" });
            if (!moveObj) return false;

            let notation = "";
            if (moveObj.san.includes("O-O")) {
                notation = moveObj.san;
            } else {
                const piece = pieceNotation[moveObj.piece];
                const capture = moveObj.captured ? "x" : "-";
                notation = `${piece}${sourceSquare}${capture}${targetSquare}`;
                if (moveObj.flags.includes("e")) notation += " e.p.";
            }

            setMoves((prevMoves) => {
                const newMoves = [...prevMoves];

                if (newGame.turn() === "b") {
                    newMoves.push({ moveNumber: newMoves.length + 1, whiteMove: notation, blackMove: "" });
                } else {
                    if (newMoves.length > 0) {
                        newMoves[newMoves.length - 1].blackMove = notation;
                    }
                }

                return newMoves;
            });

            return true;
        }

        return false;
    }

    return (
        <div className="chess-container">
            <div className="board-container">
                <h1>Chess Game</h1>
                <div className="chessboard-wrapper">
                    <Chessboard position={game.fen()} onPieceDrop={onDrop} boardWidth={600} />
                </div>
            </div>

            <div className="moves-list">
                <h2>Game Moves</h2>
                <div className="moves-scroll">
                    {moves.map(({ moveNumber, whiteMove, blackMove }) => (
                        <div key={moveNumber} className="move-container">
                            <span className="move-number">{moveNumber}.</span>
                            <span className="move">{whiteMove}</span>
                            <span className="move">{blackMove ? blackMove : ""}</span>
                        </div>
                    ))}
                </div>
            </div>

            <div className="button-container">
                <Link to="/personal">
                    <button className="action-button">Back</button>
                </Link>
            </div>
        </div>
    );
};

export default ChessPage;
