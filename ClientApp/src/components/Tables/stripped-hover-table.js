import React from 'react';
import { Table } from 'reactstrap'; 


const StrippedHoverTable = ({children}) =>{
    return(<Table striped hover>
        {children}

    </Table>)
}

export default StrippedHoverTable;