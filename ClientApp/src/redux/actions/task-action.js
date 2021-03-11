import axios from 'axios';
export const GET_TASKS_BY_USER  = 'get_tasks_by_user';
export const ADD_TASK           = 'add_task'
export const DELETE_TASK        = 'delete_task'
export const UPDATE_TASK        = 'update_task';

const BASE_URL = 'api/Tasks/'

const taskAction = (type,obj) =>{

    switch(type){
        case GET_TASKS_BY_USER:
            return dispatch =>{
                axios.get(BASE_URL + obj.id).then(({data})=>{
                        dispatch({type:GET_TASKS_BY_USER,payload:data});
                })
            }
        case ADD_TASK:
            return dispatch =>{
                axios.post(BASE_URL,obj).then(({data})=>{
                    dispatch({type:ADD_TASK,payload:data})
                })
            }
        case UPDATE_TASK:
            return dispatch =>{
                axios.put(BASE_URL ,obj).then(({data})=>{
                    dispatch({type:UPDATE_TASK,payload:data})
                })
            }
        case DELETE_TASK:
            return dispatch =>{
                axios.delete(BASE_URL + obj.id).then(()=>{
                    dispatch({type:DELETE_TASK,payload:{id:obj.id}});
                })
            }
    }

}

export default taskAction;

