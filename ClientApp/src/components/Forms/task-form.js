import React, { useState } from 'react';
import { Form, Button } from 'reactstrap';
import {useDispatch} from 'react-redux';

import AppInput from './input';
import tasksAction, { ADD_TASK } from '../../redux/actions/task-action';
import ValidationHelper from '../../helpers/validation-helper';

const TaskForm = (props) => {
    const {userId}                      = props;
    const [title, setTitle]             = useState('');
    const [description, setDescription] = useState('');
   
    const dispatch                      = useDispatch();

    const isFormValid = () =>{
       if(!ValidationHelper.hasValue(title) ){
           return false;
       }
       if(!ValidationHelper.isUserIdValid(props.userId)){
           return false;
       }

       return true;

    }
    const onSubmit = (e) =>{
    
        e.preventDefault();
        if(isFormValid()){
            dispatch(tasksAction(ADD_TASK,{title,description,userId}));
        }
        

    }

    return (<Form>
        <AppInput
            placeholder={"Enter task's title"}
            onChange={setTitle}
            name={'title'}
            type={'text'}
        />

        <AppInput
            placeholder={"Enter task's description"}
            onChange={setDescription}
            name={'description'}
            type={'text'}
        />
      
        <Button color="primary" onClick={onSubmit}>Do Something</Button>{' '}
      
    </Form>)
}

export default TaskForm;