import { reactive } from 'vue'

export const store = reactive({
    todos: [],
    todoID: 0,
    addTodo(context){
        this.todos.push({id: this.todoID++, text: context});
    },
    getTodo(id){
        return this.todos.find(td => td.id == id);
    },
    deleteTodo(id){
        let i = this.todos.map(item => item.id).indexOf(id);
        this.todos.splice(i, 1);
    }
})