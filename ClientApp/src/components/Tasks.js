import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { Button } from 'reactstrap'

import tasksAction, { GET_TASKS_BY_USER } from '../redux/actions/task-action';
import StrippedHoverTable from '../components/Tables/stripped-hover-table';
import TasksTableRow from '../components/Tables/TableRows/task-table-row';
import TasksTableHeader from '../components/Tables/TableRows/task-table-header';
import Modal from '../components/Modals/modal';
import TaskForm from '../components/Forms/task-form';

export const Tasks = ({match}) => {
  const id                              = match.params.id;
  const dispatch                        = useDispatch();
  const tasks                           = useSelector(state => state.tasks);
  const [isModalOpen, setIsModalOpen]   = useState(false);

  const openModal = () => {
    setIsModalOpen(true);
  }

  const closeModal = () => {
    setIsModalOpen(false);
  }

  const getRows = () => {
    if (tasks) {
      return tasks.map((item, index) => <TasksTableRow key={index} item={item} />)
    }
  }
  useEffect(() => {
    dispatch(tasksAction(GET_TASKS_BY_USER, { id }))
  }, [])


  return (<div>
    <Button color={'primary'} style={{marginBottom:'5px'}} onClick={openModal} >Add</Button>
    <Modal isOpen={isModalOpen} onCloseClicked={closeModal} >
      <TaskForm userId={1}/>
    </Modal>
    <StrippedHoverTable>
      <TasksTableHeader />
      <tbody>
        {getRows()}
      </tbody>
    </StrippedHoverTable>
  </div>)

}