import React, { useState } from "react";
import store from "../store/store";

export default function AddTodo(props) {
  const [input, setInput] = useState("");

  const handleAddTodo = () => {
    store.dispatch({ type: "ADD", content: input });
    setInput("");
  };

  return (
    <div>
      <input onChange={(e) => setInput(e.target.value)} value={input} />
      <button className="add-todo" onClick={handleAddTodo}>
        Add Todo
      </button>
    </div>
  );
}
