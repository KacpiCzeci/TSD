import React, { useState } from "react";
import { calculateWinner } from "../calculateWinner";
import Board from "./Board";

export default function Game() {
  const [isStarted, setIsStarted] = useState(false);
  const [game, setGame] = useState(Array(9).fill(null));
  const [xIsNext, setXisNext] = useState(true);
  const winner = calculateWinner(game);
  const xO = xIsNext ? "X" : "O";

  const handleClick = (i) => {
    setIsStarted(true);
    const squares = [...game];

    if (winner || squares[i]) return;

    squares[i] = xO;
    setGame(squares);
    setXisNext(!xIsNext);
  };

  const resetGame = () => {
    setGame(Array(9).fill(null));
    setIsStarted(false);
  };

  return (
    <div className="game">
      <div className="choose-player">
        <button
          className={`button-player${isStarted ? "-disabled" : ""}`}
          onClick={() => setXisNext(true)}
        >
          X
        </button>
        <button
          className={`button-player${isStarted ? "-disabled" : ""}`}
          onClick={() => setXisNext(false)}
        >
          O
        </button>
      </div>
      <Board squares={game} onClick={handleClick} />
      <div className="info-container">
        <h3 className="info">
          {winner ? "Winner: " + winner : "Next Player: " + xO}
        </h3>
        <button className="button-reset" onClick={resetGame}>
          Reset
        </button>
      </div>
    </div>
  );
}
