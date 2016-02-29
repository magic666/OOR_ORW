function createReq(){
    var req = null;
    if(window.XMLHttpRequest){
        req = new XMLHttpRequest();
    }else{
        req = new ActiveXObject("Microsoft.XMLHTTP");
    }
    return req;
}/**
 * Created by Magic on 2016-01-26.
 */
