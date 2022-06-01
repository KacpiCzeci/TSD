import React from "react";
import store from "../store/store";

export default function Todo({ todo }) {
  return (
    <li className="todo-item">
      <span className="todo-item-content">{todo.content}</span>
      <button onClick={() => store.dispatch({ type: "DELETE", id: todo.id })}>
        X
      </button>
    </li>
  );
}
