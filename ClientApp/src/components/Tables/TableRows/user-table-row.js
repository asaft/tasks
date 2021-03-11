import React from 'react';
import {Link} from 'react-router-dom';

const TaskTableRow = ({item}) =>{

    return(<tr>
        <td>{item.id}</td>
        <td>{item.firstName}</td>
        <td>{item.lastName}</td>
        <td>{item.userName}</td>
        <td><Link to={"/tasks/" + item.id}>go to tasks</Link></td>
        
    </tr>)
}

export default  TaskTableRow;