import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import {
  Home,
  CreateAndEditGame,
  Games,
  SignIn,
  Admins,
  Library,
  SignUp,
  Suport,
  Game
} from './pages';
import Layout from './components/Layout';
import { isLoggedd, isAdmin, isMaster } from './App';

//Common Routes
/**
 * /
 * /store/pc
 * /store/ps4
 * /store/xbox
 * /sign-in
 * /sign-up
 * /suport
 * /game/:id
 * /change-password/:id
 */

//Customer Routes
/**
 * /library
 */

//Admin routes
/**
 * /admin/games
 * /admin/games/new
 * /admin/games/edit/:id
 */

//Master routes
/**
 * /master/admins
 */

const renderRoute = (Page, withLayout = true) => props =>
  withLayout ? (
    <Layout>
      <Page {...props} />
    </Layout>
  ) : (
    <Page {...props} />
  );

const PrivateRoute = ({ adminOlny, masterOnly, ...props }) => {
  let authorized = true;

  if (!isLoggedd()) {
    authorized = false;
  }

  if (adminOlny && !isAdmin()) {
    authorized = false;
  }

  if (masterOnly && !isMaster()) {
    authorized = false;
  }

  if (isMaster()) {
    authorized = true;
  }

  return authorized ? <Route {...props} /> : <Redirect to="/sign-in" />;
};

const Routes = () => (
  <Switch>
    <Route exact path="/" render={renderRoute(Home)} />
    <Route exact path="/store/:plataform" render={renderRoute(Home)} />
    <Route exact path="/sign-in" render={renderRoute(SignIn, false)} />
    <Route exact path="/sign-up" render={renderRoute(SignUp, false)} />
    <Route exact path="/suport" render={renderRoute(Suport)} />
    <Route exact path="/game/:id" render={renderRoute(Game)} />
    <PrivateRoute exact path="/library" render={renderRoute(Library)} />

    {/*ADMIN PAGES*/}
    <PrivateRoute
      exact
      adminOlny
      path="/admin/games"
      render={renderRoute(Games)}
    />
    <PrivateRoute
      exact
      adminOlny
      path="/admin/games/new"
      render={renderRoute(CreateAndEditGame)}
    />
    <PrivateRoute
      exact
      adminOlny
      path="/admin/games/edit/:id"
      render={renderRoute(CreateAndEditGame)}
    />

    {/* MASTER PAGES */}
    <PrivateRoute
      exact
      masterOnly
      path="/master/admins"
      render={renderRoute(Admins)}
    />
    <Route
      render={function() {
        return <h1>Not Found</h1>;
      }}
    />
  </Switch>
);

export default Routes;
