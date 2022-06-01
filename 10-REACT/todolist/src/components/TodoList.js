import React from "react";
import Todo from "./Todo";
import { useSelector } from "react-redux";

export default function TodoList() {
  const todos = useSelector((state) => state.todos);

  return (
    <ul className="todo-list">
      {todos.length !== 0
        ? todos.map((todo, index) => {
            return <Todo key={`todo-${todo.id}`} todo={todo} />;
          })
        : "No todos, yay!"}
    </ul>
  );
}
