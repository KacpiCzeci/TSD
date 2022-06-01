import "./styles.css";
import { useState } from "react";

export default function App() {
  const [count, setCount] = useState(0);

  return (
    <div className="App">
      <h1 className={count > 0 ? "Positive" : count < 0 ? "Negative" : "Zero"}>
        {count}
      </h1>
      <div className="Button-container">
        <button className="Button" onClick={() => setCount(count - 1)}>
          -
        </button>
        <button className="Button" onClick={() => setCount(count + 1)}>
          +
        </button>
      </div>
    </div>
  );
}
