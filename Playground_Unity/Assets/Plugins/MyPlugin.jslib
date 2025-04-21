mergeInto(LibraryManager.library, {
    SetAPIValueFromUnity: function(namePtr, valuePtr) {
        var name = UTF8ToString(namePtr);
        var value = UTF8ToString(valuePtr);

        if (typeof setApiValue === "function") {
            SetAPIFromUnity(name, value);
        } else {
            console.log("setApiValue is not defined.");
        }
    }
});
mergeInto(LibraryManager.library, {
    SendCameraPositionToJS: function (x, y, z) {
        // console.log("Camera Position from Unity:", x, y, z);
        window.ReceiveCameraPosition(x, y, z);
    }
});
mergeInto(LibraryManager.library, {
    ShowInfo: function (infoPtr) {  
        var info = UTF8ToString(infoPtr);     
        window.ShowInfo(info)
    }
});
