import React from 'react';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import  {faTrashAlt,faTasks} from '@fortawesome/free-solid-svg-icons';
import {useDispatch} from 'react-redux';

import tasksAction, { UPDATE_TASK, DELETE_TASK } from '../../../redux/actions/task-action';
import TaskHelper,{DONE,UNDONE} from '../../../helpers/task-helper';
import DateFormatHelper from '../../../helpers/date-helper';

const TaskTableRow = ({item}) =>{

    const dispatch = useDispatch();
    const updateTaskStatus = (status) =>{
        item.taskStatus = status
        dispatch(tasksAction(UPDATE_TASK,item));
    }

    const removeTask = () =>{
        dispatch(tasksAction(DELETE_TASK,{id:item.id}));
    }
    return(<tr style={{background:(item.taskStatus == DONE ? '#c2c2c2' : '#fff')}} >
        <td onClick={()=>updateTaskStatus(DONE)}>{item.id}</td>
        <td onClick={()=>updateTaskStatus(DONE)}>{item.title}</td>
        <td onClick={()=>updateTaskStatus(DONE)}>{item.description}</td>
        <td onClick={()=>updateTaskStatus(DONE)}>{DateFormatHelper.getDateTimeFormat(item.updatedAt)}</td>
        <td onClick={()=>updateTaskStatus(DONE)}>{TaskHelper.getTaskStatus(item.taskStatus)}</td>
        <td><span onClick={removeTask} style={{cursor:'pointer'}}>
            <FontAwesomeIcon icon={faTrashAlt} />
             </span>{' '}
             <span onClick={()=>updateTaskStatus(UNDONE)} style={{cursor:'pointer'}}>
            <FontAwesomeIcon icon={faTasks} />
             </span>
             </td>
    </tr>)
}

export default  TaskTableRow;