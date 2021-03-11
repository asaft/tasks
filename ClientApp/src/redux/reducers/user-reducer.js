import {GET_ALL_USERS} from '../actions/user-action';

const usersReducer = (state = [],{type,payload}) =>{
    switch(type){
        case GET_ALL_USERS:
            return payload;
            default:
                return state;
    }
}

export default usersReducer;