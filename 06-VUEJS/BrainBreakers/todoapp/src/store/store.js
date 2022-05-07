import { createStore } from 'vuex'
import axios from 'axios';

export const store = createStore({
    state () {
      return {
        todos: [],
        todoID: 201,
      }
    },
    getters: {
        getAll(state){
            return state.todos;
        },
        getByTitle: (state) => (title) => {
            let regex = new RegExp('\\b^.*' + title + '.*$\\b');
            return  state.todos.filter(todo => regex.test(todo.title));
        },
        getTodo: (state) => (id) => {
            return state.todos.find(td => td.id == id);
        },
        getTodoLen(state){
            return state.todos.length;
        }
    },
    mutations: {
        initData(state, context){
            state.todos.push(... context);
        },
        addTodo(state, context){
            state.todos.push({userId: 1, id: state.todoID++, title: context.title, completed: context.done});
        },
        updateTodo(state, context){
            state.todos = state.todos.map(item => {
                if(item.id == context.id){
                    return {userId: item.userId, id: item.id, title: item.title, completed: context.done};
                }
                else{
                    return item;
                }
            })
        }, 
        deleteTodo(state, id){
            let i = state.todos.map(item => item.id).indexOf(id);
            state.todos.splice(i, 1);
        }
    },
    actions: {
        initData(context){
            axios
            .get('https://jsonplaceholder.typicode.com/todos')
            .then(response => {
                context.commit('initData', response.data);
                localStorage.setItem('todos', JSON.stringify(response.data));
                localStorage.setItem('loaded', JSON.stringify(true));
            });
        },
        setTodos(context, todos){
            context.commit('initData', todos);
            localStorage.setItem('todos', JSON.stringify(context.state.todos));
        },
        addTodo(context, text, details, done){
            context.commit('addTodo', text, details, done);
            localStorage.setItem('todos', JSON.stringify(context.state.todos));
        },
        updateTodo(context, id, done){
            context.commit('updateTodo', id, done);
            localStorage.setItem('todos', JSON.stringify(context.state.todos));
        },
        deleteTodo(context, id){
            context.commit('deleteTodo', id);
            localStorage.setItem('todos', JSON.stringify(context.state.todos));
        }
    }
})