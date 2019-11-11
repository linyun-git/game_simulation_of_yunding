var i=true
function exit(){
    document.getElementById('out').style.zIndex='2';
    document.getElementById('tips').style.height='90px';
    setTimeout("document.getElementById('ok').style.background='#317bd5'",500);
    setTimeout("document.getElementById('ok').style.borderColor='#317bd5'",500);
    setTimeout("document.getElementById('no').style.background='#cd394b'",500);
    setTimeout("document.getElementById('no').style.borderColor='#cd394b'",500);
    setTimeout("document.getElementById('no-div1').style.background='#fff'",500);
    setTimeout("document.getElementById('no-div2').style.background='#fff'",500);
    setTimeout("document.getElementById('tips').style.color='#000'",500);
}
function cancel(){
    i=false;
    document.getElementById('exittip').style.width='100px';
    document.getElementById('ok').style.background='#d7d7d7';
    document.getElementById('ok').style.borderColor='#d7d7d7';
    document.getElementById('no').style.background='#d7d7d7';
    document.getElementById('no').style.borderColor='#d7d7d7';
    document.getElementById('no-div1').style.background='#d7d7d7';
    document.getElementById('no-div2').style.background='#d7d7d7';
    document.getElementById('tips').style.color='#c6c6c6';
    setTimeout("document.getElementById('out').style.zIndex='0'",300);
    setTimeout("document.getElementById('tips').style.height='20px'",300);
    setTimeout("document.getElementById('exittip').style.width='340px'",300);
    i=true;
}