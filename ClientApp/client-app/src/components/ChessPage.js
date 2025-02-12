import React, { useEffect, useState } from "react";
import { Chessboard } from "react-chessboard";
import { Chess } from "chess.js";

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
            const piece = pieceNotation[moveObj.piece];
            const lastMove = `${piece}${sourceSquare}-${targetSquare}`;

            setMoves((prevMoves) => {
                const newMoves = [...prevMoves];

                if (newGame.turn() === "b") {
                    newMoves.push({ moveNumber: newMoves.length + 1, whiteMove: lastMove, blackMove: "" });
                } else {
                    if (newMoves.length > 0) {
                        newMoves[newMoves.length - 1].blackMove = lastMove;
                    }
                }

                return newMoves;
            });

            return true;
        }

        return false;
    }

    return (
        <div className="flex justify-center items-center h-screen bg-[#1b1b1b]">
            <div className="flex flex-col items-center bg-[#2d1b0b] p-5 rounded-xl shadow-lg">
                <div className="border-4 border-[#7b5d41] rounded-lg p-2">
                    <Chessboard
                        position={game.fen()}
                        onPieceDrop={onDrop}
                        boardWidth={450}
                        customBoardStyle={{
                            backgroundColor: "#3e2c20",
                        }}
                        customDarkSquareStyle={{
                            backgroundColor: "#7b5d41",
                        }}
                        customLightSquareStyle={{
                            backgroundColor: "#e6d2b5",
                        }}
                    />
                </div>

                <div className="mt-6 w-56 min-w-[450px] bg-[#3e2c20] p-3 rounded-lg text-white shadow-md">
                    <h2 className="text-lg font-bold text-center">Recording a chess game</h2>
                    <div className="mt-3 h-72 overflow-y-auto">
                        {moves.map(({ moveNumber, whiteMove, blackMove }) => (
                            <p key={moveNumber} className="text-sm py-1 border-b border-[#7b5d41]">
                                {moveNumber}. {whiteMove} {blackMove ? blackMove : " "}
                            </p>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ChessPage;