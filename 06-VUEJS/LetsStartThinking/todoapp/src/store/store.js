import { createStore } from 'vuex'

export const store = createStore({
    state () {
      return {
        todos: [],
        todoID: 0,
      }
    },
    getters: {
        getAll(state){
            return state.todos;
        },
        getTodo: (state) => (id) => {
            return state.todos.find(td => td.id == id);
        },
        getTodoLen(state){
            return state.todos.length;
        }
    },
    mutations: {
        addTodo(state, context){
            state.todos.push({id: state.todoID++, text: context.title, details: context.details, finished: context.done});
        },
        updateTodo(state, context){
            state.todos = state.todos.map(item => {
                if(item.id == context.id){
                    return {id: item.id, text: item.text, details: item.details, finished: context.done};
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
        addTodo(context, text, details, done){
            context.commit('addTodo', text, details, done);
        },
        updateTodo(context, id, done){
            context.commit('updateTodo', id, done);
        },
        deleteTodo(context, id){
            context.commit('deleteTodo', id);
        }
    }
})