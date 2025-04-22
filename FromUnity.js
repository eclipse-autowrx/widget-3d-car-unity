function sayHello() {
      alert("Hello");
}
function ShowInfo(info) {
      // console.log("Info sent from Unity is: ----------->  " + Number(info));
}

function SetAPIFromUnity(name, value) {
      // console.log(`Unity request set component ${name} ------>  ${value}`)
      try {
            let found = false
            if(OBJECT_MAPPING && name && setApiValue) {
                  OBJECT_MAPPING.forEach(obj => {
                        if(obj.unity_name && obj.unity_name == name && obj.api) {
                              setApiValue(obj.api, value); 
                              found = true
                        }
                  })
            }
            if(!found) console.log("NOT FOUND", name)
      } catch(e) {
            console.log(e)
      }
}

function ReceiveCameraPosition(x, y, z) {
      const driver_x = -1.7
      const driver_y = 0.98
      const driver_z = 2.410

      try {
            if(WIDGET_OPTIONS) {
                  // deverloper mode
                  if(!!WIDGET_OPTIONS.developer_mode){
                        let divDeveloper = document.getElementById("panelDeveloper")
                        let divXval = document.getElementById("camXval")
                        let divYval = document.getElementById("camYval")
                        let divZval = document.getElementById("camZval")
                        if(divDeveloper) {
                              divDeveloper.classList.remove('hidden');
                              divDeveloper.classList.add('fixed');
                        } else {
                              console.log(">>>>>>>>>>>>>>>> NO divDeveloper")
                        }
                        if(divXval) {
                              divXval.textContent = x.toFixed(1)
                        }
                        if(divYval) {
                              divYval.textContent = y.toFixed(1)
                        }
                        if(divZval) {
                              divZval.textContent = z.toFixed(1)
                        }
                  }

                  // Proximity: distance between driver and car
                  let distance = 2.4*(Math.abs(x-driver_x) + Math.abs(y-driver_y))
                  if(WIDGET_OPTIONS.proximity_signal_name && setApiValue) {
                        setApiValue(WIDGET_OPTIONS.proximity_signal_name, distance.toFixed(2))
                  }
                  
                  let divDistance = document.getElementById("distance")
                  let divDistanceVal = document.getElementById("distanceVal")
                  if(divDistance && divDistanceVal) {
                        if(!!WIDGET_OPTIONS.show_proximity_value) {
                              divDistanceVal.textContent  = distance.toFixed(2)
                              divDistance.classList.remove('hidden');
                              divDistance.classList.add('fixed');
                        }
                  }
            }
            
      } catch(e) {}
};
