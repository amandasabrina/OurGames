import React from 'react';

import { Typography, Link } from '@material-ui/core';

export default function Footer() {
  return (
    <footer className="p-3 mt-auto">
      <Typography variant="body2" className="textPrimary" align="center">
        {'Copyright © '}
        <Link color="inherit" href="">
          OurGames
        </Link>{' '}
        {new Date().getFullYear()}
        {'.'}
      </Typography>
      <Typography variant="body2" className="textSecondary" align="center">
        {'Desenvolvido por '}
        <Link color="inherit" href="">
          {'N&W'} Solutions
        </Link>
        {'.'}
      </Typography>
    </footer>
  );
}
