import _ from 'underscore';

class ArrayHelper {
    static getElementById(arr,id){
        const index = _.findIndex(arr,{id});
        return arr[index];
    }
    static removeItemById(array,id){
        const index = _.findIndex(array,{id});
        return [...array.slice(0,index ),...array.slice(index + 1, array.length)];
    }
    static updateElementById(arr,element){
        const {id} = element;
        const index = _.findIndex(arr,{id});
        arr[index] = element;
        return arr;
    }
}

export default ArrayHelper;