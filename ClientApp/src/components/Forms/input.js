import React from 'react';
import {Input ,FormGroup,Label} from 'reactstrap';

const AppInput = ({onChange,name,type,placeholder}) =>{
    return(<FormGroup>
         <Label for={name}>{placeholder}</Label>
        <Input type={type || 'text'} onChange={({target})=>{onChange(target.value)}} name={name} id={name} placeholder={placeholder}/>
    </FormGroup>);
}

export default AppInput;