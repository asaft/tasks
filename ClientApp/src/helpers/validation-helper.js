class ValidationHelper{

    static hasValue(val){
        if(val !== undefined && val !== null && val !== '' ){
            return true;
        }

        return false
    }

    static isUserIdValid(userId){
        if(userId !== undefined && userId !== null && userId > 0){
            return true;
        }

        return false
    }
    static isDateValid(date){debugger;
        if(date === undefined && date === null){
            return false;
        }
        if(typeof date  === 'string'){
            date = new Date(date);
        }

        return true
    }
}

export default ValidationHelper;