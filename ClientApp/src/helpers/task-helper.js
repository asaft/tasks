

const STATUSARRAY = ["undone","done"]
export const UNDONE = 0;
export const DONE   = 1;
class TaskHelper {
    static getTaskStatus(value){
        return STATUSARRAY[value];
    }
}

export default TaskHelper;