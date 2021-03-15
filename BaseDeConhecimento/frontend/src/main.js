import "font-awesome/css/font-awesome.css";
import "@fortawesome/vue-fontawesome";
import "@fortawesome/fontawesome-svg-core";
import "@fortawesome/free-solid-svg-icons";
import Vue from "vue";

import App from "./App";

import "./config/bootstrap";
import "./config/msgs";
import store from "./config/store";
import router from "./config/router";

Vue.config.productionTip = false;

// TEMPORARIO!
require("axios").defaults.headers.common["Authorization"] =
  "bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpZCI6MiwibmFtZSI6IkpvYW9EaWFzQWRtaW4iLCJlbWFpbCI6ImpvYW9kaWFzd29ya2luZ0FkbWluQGdtYWlsLmNvbSIsImFkbWluIjp0cnVlLCJpYXQiOjE2MTU3NjI2MDcsImV4cCI6MTYxNjAyMTgwN30.35JMulV3-bjKaGzQt-ApdwuBU9zMefMZMdjGQiYUorI";

new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount("#app");
