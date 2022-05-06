import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AddNewTodoView from '../views/AddNewTodoView.vue'
import DetailsView from '../views/DetailsView.vue'
import NotFoundWiew from '../views/NotFoundWiew.vue'
import { store } from '../store/store.js'

const routes = [
  { 
    path: '/',
    name: 'home',
    component: HomeView,
    children: [{
      path: 'details/:id',
      name: 'details',
      component: DetailsView,
      beforeEnter: (to, from, next) => {
        function isValid(param) {
          return store.getters.getTodo(param) == undefined;
        }
  
        if(isValid(to.params.id)){
          next({name:'404-NotFound'});
        }
        else{
          next();
        }
      }
    }]
  },
  {
    path: '/add',
    name: 'add',
    component: AddNewTodoView
  },
  {
    path: '/404',
    name: '404-NotFound',
    component: NotFoundWiew
  },
  {
    path: "/:catchAll(.*)",
    redirect: '/404',
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
