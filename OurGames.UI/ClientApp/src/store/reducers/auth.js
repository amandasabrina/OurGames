import { createReducer } from 'redux-act';
import * as a from '../actions/auth';

const getDefaultState = _ => ({
  user: undefined,
  signOut: _ => {},
  signInWithGoogle: _ => {},
  signInWithFacebook: _ => {},
  signInWithEmailAndPassword: _ => {},
  createUserWithEmailAndPassword: _ => {},
  fauth: {},
  isAdmin: false,
  isMaster: false
});

export default _ =>
  createReducer(
    {
      [a.setFirebaseOptions]: (
        state,
        {
          user,
          signOut,
          signInWithGoogle,
          signInWithFacebook,
          signInWithEmailAndPassword,
          createUserWithEmailAndPassword,
          fauth
        }
      ) => ({
        ...state,
        user,
        signOut,
        signInWithGoogle,
        signInWithFacebook,
        signInWithEmailAndPassword,
        createUserWithEmailAndPassword,
        fauth
      }),
      [a.setUser]: (state, user) => ({ ...state, user }),
      [a.setAccess]: (state, accessId) => ({
        ...state,
        isAdmin: accessId === 2,
        isMaster: accessId === 3
      })
    },
    getDefaultState()
  );
