import axios from 'axios';
export const GET_ALL_USERS = 'get_all_users';
const BASE_URL = '/api/users'

const userAction = (type) =>{

    switch(type){
        case GET_ALL_USERS:
            return dispatch =>{
                axios.get(BASE_URL).then(({data})=>{
                    dispatch({type:GET_ALL_USERS,payload:data});
                })
            }
            default:
    }
}

export default userAction;