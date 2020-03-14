import { takeIfExists } from './localStorage';

/* global localStorage:true */

export const loggedIn = () => {
  const expirationTime = localStorage.getItem('tokenExpirationTime');

  const isLogged = new Date().getTime() / 1000 < parseInt(expirationTime, 10);

  !isLogged && logOut();

  return isLogged;
};

export const logOut = () => {
  localStorage.removeItem('token');
  localStorage.removeItem('tokenExpirationTime');
  localStorage.removeItem('email');
  localStorage.removeItem('fullName');
  localStorage.removeItem('accessLevel');
  localStorage.removeItem('isPharma');
  localStorage.removeItem('userId');

  // const coo = read_cookie('.AuthCookie');

  // console.log(coo);

  // document.cookie = '.AuthCookie= ;';
};

export const isAdmin = () => takeIfExists('accessLevel', Number) === 1;

export const logIn = ({
  token,
  tokenExpirationTime,
  email,
  fullName,
  accessLevel,
  segment,
  userId
}) => {
  localStorage.setItem('token', token);
  localStorage.setItem('tokenExpirationTime', tokenExpirationTime);
  localStorage.setItem('email', email);
  localStorage.setItem('fullName', fullName);
  localStorage.setItem('accessLevel', accessLevel);
  localStorage.setItem('isPharma', segment === 2);
  localStorage.setItem('userId', userId);

  const cookieValue = {
    token,
    tokenExpirationTime,
    email,
    fullName,
    accessLevel,
    isPharma: segment === 2,
    userId
  };

  // const cookieExpires = new Date(parseInt(tokenExpirationTime));

  // bake_cookie('.AuthCookie', cookieValue, cookieExpires);

  // console.log(document.cookie);
};

// function bake_cookie(name, value, expires) {
//   var cookie = [
//     name,
//     '=',
//     JSON.stringify(value),
//     '; domain=.',
//     window.location.host.toString(),
//     '; path=/;'
//     // 'expires=',
//     // expires.toString()
//   ].join('');
//   document.cookie = cookie;
// }

// function read_cookie(name) {
//   var result = document.cookie.match(new RegExp(name + '=([^;]+)'));
//   result && (result = JSON.parse(result[1]));
//   return result;
// }
