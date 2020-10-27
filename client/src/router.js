import Vue from 'vue'
import Router from 'vue-router'
import Contacts from './views/Contacts.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'contacts',
      component: Contacts
    },
    {
      path: '/contact/:id?',
      name: 'contact-details',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/ContactDetails.vue')
    }
  ]
})
