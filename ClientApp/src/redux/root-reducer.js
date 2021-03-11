import { combineReducers } from 'redux'

import tasksReducer from './reducers/task-reducers';
import usersReducer from './reducers/user-reducer';

export default combineReducers({
    tasks:tasksReducer,
    users:usersReducer
});