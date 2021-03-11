import React, { useEffect } from 'react';

import {useDispatch,useSelector} from 'react-redux';
import usersAction,{GET_ALL_USERS} from '../redux/actions/user-action';
import Table from '../components/Tables/stripped-hover-table';
import UserTableHeader from '../components/Tables/TableRows/user-table-header'
import UserTableRow from '../components/Tables/TableRows/user-table-row'

export const Home =  () => {
 
  const dispatch    = useDispatch();
  const users       = useSelector(state=>state.users);

  const getRows = () =>{
    if(users){
      return users.map((item,index)=><UserTableRow key={index} item={item} />)
    }
  }

  useEffect(()=>{
    dispatch(usersAction(GET_ALL_USERS))
  },[])
  return ( <div>
          <Table>
            <UserTableHeader/>
            <tbody>
              {getRows()}
            </tbody>
          </Table>
        </div>
    );
  }
