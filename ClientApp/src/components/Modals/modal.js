import React from 'react';
import {  Modal, ModalHeader, ModalBody } from 'reactstrap';

import TaskFrom from '../Forms/task-form'

const AppModal = (props) => {
  
  return (
    <div>
     
      <Modal isOpen={props.isOpen} toggle={props.onCloseClicked} >
        <ModalHeader toggle={props.onCloseClicked}>Modal title</ModalHeader>
        <ModalBody>
            {props.children}
         </ModalBody>
       
      </Modal>
    </div>
  );
}

export default AppModal;