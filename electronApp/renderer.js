// This file is required by the index.html file and will
// be executed in the renderer process for that window.
// No Node.js APIs are available in this process because
// `nodeIntegration` is turned off. Use `preload.js` to
// selectively enable features needed in the rendering
// process.
var ali;
var image;
var hero;
var img2=document.getElementById('vn');
function setid(li){
    ali=li.id;
    document.getElementById('SelectHero').style.display="block";
    document.getElementById('start').style.display="none";
    document.getElementById('cancel').style.display="block";
    document.getElementById('go').style.display="block";
}
function cancel(){
    document.getElementById('SelectHero').style.display="none";
    document.getElementById('start').style.display="block";
    document.getElementById('cancel').style.display="none";
    document.getElementById('go').style.display="none";
}
function select(img){
    img2.style.border="blue solid 2px";
    img2=img;
    img.style.border="2px solid rgb(20, 200, 212)";
    hero = 'img/'+img.id+'.gif';
}
function Go(){
    image=ali+'-img';
    document.getElementById(image).src=hero;
    img2.style.border="2px solid blue";
    document.getElementById(image).style.display="block";
    document.getElementById('SelectHero').style.display="none";
    document.getElementById('start').style.display="block";
    document.getElementById('cancel').style.display="none";
    document.getElementById('go').style.display="none";
}