// This file is required by the index.html file and will
// be executed in the renderer process for that window.
// No Node.js APIs are available in this process because
// `nodeIntegration` is turned off. Use `preload.js` to
// selectively enable features needed in the rendering
// process.
function setid(){
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