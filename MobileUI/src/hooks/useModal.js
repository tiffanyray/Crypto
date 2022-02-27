import * as React from 'react';

export const useModal = (props) => {
  const [visible, setVisible] = React.useState(props.startingVal);
  const toggleModal = state => setVisible(false);
  const open = () => setVisible(true);
  const close = () => setVisible(false);
  
  return { visible, toggleModal, open, close };
}