// Modules to control application life and create native browser window
// const {app, BrowserWindow} = require('electron')
// const path = require('path')

// // Keep a global reference of the window object, if you don't, the window will
// // be closed automatically when the JavaScript object is garbage collected.
// let mainWindow

// function createWindow () {
//   // Create the browser window.
//   mainWindow = new BrowserWindow({
//     width: 1200,
//     height: 800,
//     frame: false,
//     resizable: false
//     // webPreferences: {
//     //   preload: path.join(__dirname, 'preload.js')
//     // }
//   })

//   // and load the index.html of the app.
//   mainWindow.loadFile('html/main.html')

//   // Open the DevTools.
//   mainWindow.webContents.openDevTools()

//   // Emitted when the window is closed.
//   mainWindow.on('closed', function () {
//     // Dereference the window object, usually you would store windows
//     // in an array if your app supports multi windows, this is the time
//     // when you should delete the corresponding element.
//     mainWindow = null
//   })
// }

// // This method will be called when Electron has finished
// // initialization and is ready to create browser windows.
// // Some APIs can only be used after this event occurs.
// app.on('ready', createWindow)





// // Quit when all windows are closed.
// app.on('window-all-closed', function () {
//   // On macOS it is common for applications and their menu bar
//   // to stay active until the user quits explicitly with Cmd + Q
//   if (process.platform !== 'darwin') app.quit()
// })

// // app.on('activate', function () {
// //   // On macOS it's common to re-create a window in the app when the
// //   // dock icon is clicked and there are no other windows open.
// //   if (mainWindow === null) createWindow()
// // })

// // In this file you can include the rest of your app's specific main process
// // code. You can also put them in separate files and require them here.

const { app, Menu ,BrowserWindow} = require('electron');
const client = require('electron-connect').client;
 
// 保持一个对于 window 对象的全局引用，不然，当 JavaScript 被 GC，
// window 会被自动地关闭
let mainWindow = null;
 
// 当 Electron 完成了初始化并且准备创建浏览器窗口的时候
// 这个方法就被调用
app.on('ready', function () {
    // 创建浏览器窗口。
    mainWindow = new BrowserWindow({
        width: 1200, height: 800,frame: false, resizable: false,
        webPreferences: {
            nodeIntegrationInWorker: true//支持多线程
        }
    });
    // 加载应用的 index.html
    mainWindow.loadURL('file://' + __dirname + '/html/main.html');
 
    // 打开开发工具
    mainWindow.openDevTools();
 
    // 当 window 被关闭，这个事件会被发出
    mainWindow.on('closed', function () {
        // 取消引用 window 对象，如果你的应用支持多窗口的话，
        // 通常会把多个 window 对象存放在一个数组里面，
        // 但这次不是。
        mainWindow = null;
    });
    client.create(mainWindow);
});