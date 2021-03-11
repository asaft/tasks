class DateFormatHelper{
  
  static  getDateTimeFormat(dateStr){
        const date = new Date(dateStr);
        const year = date.getFullYear();
        const month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : (date.getMonth() + 1) ;
        const day = date.getDate()  < 10 ? "0" + date.getDate() : date.getDate() ;
        const hours = date.getHours < 10 ? "0" + date.getHours() : date.getHours();
        const minutes = date.getMinutes < 10 ? "0" + date.getMinutes() : date.getMinutes();

        return "" + day + "/" + month + "/" + year + " " + hours + ":" + minutes;
  }
}

export default DateFormatHelper;