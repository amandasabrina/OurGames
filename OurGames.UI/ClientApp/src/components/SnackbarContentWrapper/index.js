import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import { CheckCircle, Error, Info, Close, Warning } from '@material-ui/icons';
import { amber, green } from '@material-ui/core/colors';
import { IconButton, SnackbarContent } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

const variantIcon = {
  success: CheckCircle,
  warning: Warning,
  error: Error,
  info: Info
};

const useStyles = makeStyles(theme => ({
  success: {
    backgroundColor: green[600]
  },
  error: {
    backgroundColor: theme.palette.error.dark
  },
  info: {
    backgroundColor: theme.palette.primary.main
  },
  warning: {
    backgroundColor: amber[700]
  },
  icon: {
    fontSize: 20
  },
  iconVariant: {
    opacity: 0.9,
    marginRight: theme.spacing(1)
  },
  message: {
    display: 'flex',
    alignItems: 'center'
  }
}));

export default function SnackbarContentWrapper(props) {
  const classes = useStyles();
  const { className, message, onClose, variant, actions, ...other } = props;
  const Icon = variantIcon[variant];

  const splitedMessage = message.split('\n').map((e, i) => (
    <Fragment key={i}>
      {e}
      <br />
    </Fragment>
  ));

  return (
    <SnackbarContent
      className={clsx(classes[variant], className)}
      aria-describedby="client-snackbar"
      message={
        <span id="client-snackbar" className={classes.message}>
          <Icon className={clsx(classes.icon, classes.iconVariant)} />
          {splitedMessage}
        </span>
      }
      action={[
        ...(actions || []),
        <IconButton
          key="close"
          aria-label="close"
          color="inherit"
          onClick={onClose}
        >
          <Close className={classes.icon} />
        </IconButton>
      ]}
      {...other}
    />
  );
}

SnackbarContentWrapper.propTypes = {
  className: PropTypes.string,
  message: PropTypes.string,
  onClose: PropTypes.func,
  variant: PropTypes.oneOf(['error', 'info', 'success', 'warning']).isRequired
};
