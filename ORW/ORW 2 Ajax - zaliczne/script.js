var licznik = 0;
function getData (NaszPlik, divID){
    var req = createReq();
    req.open("GET", NaszPlik, true);
    req.onreadystatechange = function(){
        if(req.readyState==4 && req.status==200){
            if (licznik>=3){
                licznik=0;
                document.getElementById(divID).innerHTML = "";
            }
            else {
                licznik ++;
                document.getElementById(divID).innerHTML += "Otwarcie numer:"+licznik+" Nasz plik: "+req.responseText+"<br/>";
            }
        }
    }
    req.send(null);
}
/**
 * Created by Magic on 2016-01-26.
 */
