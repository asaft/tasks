import {
        GET_TASKS_BY_USER,
        ADD_TASK,
        UPDATE_TASK,
        DELETE_TASK} from '../actions/task-action';

import ArrayHelper from '../../helpers/arrayHelper';


const taskReducer = (state = [], {payload,type}) =>{
   
    switch(type){
        case GET_TASKS_BY_USER:
            return payload;
        case ADD_TASK:
            state.push(payload);
            return [...state];
        case UPDATE_TASK:
            debugger;
            const arr = ArrayHelper.updateElementById(state,payload);
            return [...arr];
        case DELETE_TASK:
            return ArrayHelper.removeItemById(state,payload.id);
            default:
                return state;
    }
}

export default taskReducer