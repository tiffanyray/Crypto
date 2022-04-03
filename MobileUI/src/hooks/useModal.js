import * as React from 'react';

export const useModal = ({ startingVal = false }) => {
  const [visible, setVisible] = React.useState(startingVal);
  const toggleModal = state => setVisible(false);
  const open = () => setVisible(true);
  const close = () => setVisible(false);
  
  return { visible, toggleModal, open, close };
}