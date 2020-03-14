import axios from 'axios';
import { BACKEND } from '../constants/urls';

const api = axios.create({
  baseURL: BACKEND,
  headers: {
    'Access-Control-Allow-Origin': '*',
    'Content-Type': 'application/json; charset=utf-8'
  }
});

// api.interceptors.request.use(function(config) {
//   const token = `Bearer ${localStorage.getItem('token')}`;

//   config.headers.Authorization = token;

//   return config;
// });

export default api;
