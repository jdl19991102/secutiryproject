function dateFormate(value){
  let date=value;
 
   date.forEach(item => {
    var time = item.posttime*1000
    var d = new Date(time)
    var y = d.getFullYear()
    var m = (d.getMonth() + 1) < 10 ? "0" + (d.getMonth()+1) : (d.getMonth()+1)
    var day = d.getDate()<10? "0" +d.getDate() : d.getDate()
    var posttime = y + "-" + m + "-" + day
    item.posttime = posttime 
  });
  return date;
}
module.exports={
  dateFormate

}