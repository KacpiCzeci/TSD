const initState = {
  id: 0,
  todos: []
};

export default function reducer(state = initState, action) {
  switch (action.type) {
    case "ADD":
      return {
        ...state,
        id: state.id + 1,
        todos: [...state.todos, { id: state.id++, content: action.content }]
      };

    case "DELETE":
      return {
        ...state,
        todos: state.todos.filter((todo) => todo.id !== action.id)
      };

    default:
      return {
        ...state
      };
  }
}
