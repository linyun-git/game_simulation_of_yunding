const electron = require("electron");
const { app, ipcMain, BrowserWindow, session} = electron;

var myWork;
app.on("ready", (e) => {
    myWork = new BrowserWindow({
        center: true,
        webPreferences: {
            plugins: true,
            allowDisplayingInsecureContent: true,
            allowRunningInsecureContent: true,
        }
    });
    myWork.loadURL(__dirname + "/index.html");
    myWork.show();
});
