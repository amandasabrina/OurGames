import { createReducer } from 'redux-act';
import * as a from '../actions/auth';
import { takeIfExists } from '../../utils/localStorage';
import { loggedIn } from '../../utils/auth';

const getDefaultState = _ => ({
  userId: takeIfExists('userId'),
  token: takeIfExists('token'),
  tokenExpirationTime: takeIfExists('tokenExpirationTime', Number),
  email: takeIfExists('email'),
  fullName: takeIfExists('fullName'),
  isPharma: takeIfExists('isPharma', Boolean),
  accessLevel: takeIfExists('accessLevel', Number),
  isAuthenticated: loggedIn(),
  isAdmin: takeIfExists('accessLevel', Number) === 1
});

export default _ =>
  createReducer(
    {
      [a.receiveAuthData]: (
        state,
        {
          userId,
          token,
          tokenExpirationTime,
          email,
          fullName,
          segment,
          accessLevel,
          isAuthenticated
        }
      ) => ({
        ...state,
        userId,
        token,
        tokenExpirationTime,
        email,
        fullName,
        isPharma: segment === 2,
        accessLevel,
        isAuthenticated: isAuthenticated,
        isAdmin: accessLevel === 1
      }),
      [a.unauthorizeUser]: () => ({})
    },
    getDefaultState()
  );
