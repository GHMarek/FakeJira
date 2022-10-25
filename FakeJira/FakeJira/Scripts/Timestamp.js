
setInterval(distime, 1000);


function distime() {
    var dt = new Date();
    //var time = dt.getHours() + ":" + dt.getMinutes() + ":" + ((dt.getSeconds().length == 1) ? dt.getSeconds() : '0' + dt.getSeconds()); 
    var time = (dt.getHours().toString().length == 1 ? '0' + dt.getHours() : dt.getHours()) + ":"
        + (dt.getMinutes().toString().length == 1 ? '0' + dt.getMinutes() : dt.getMinutes()) 
        + ":" + (dt.getSeconds().toString().length == 1 ? '0' + dt.getSeconds() : dt.getSeconds()); 

    $("#timestamp_id").html(time);
};