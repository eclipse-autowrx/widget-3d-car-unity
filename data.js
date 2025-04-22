var SIGNAL_MAP = [
    {
        entity: 'row1_door1',//param for Unity (entity)
        behaviour: "",//for check "islocked"
        optionsName: 'row1_door1_open',//field on browser
        api: 'Vehicle.Cabin.Door.Row1.DriverSide.IsOpen',//API defaul
        unity_name: "row1_door1",
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",//value return from browser and value send to Unity (action)
            "false": "false"
        }
    },
    {
        entity: 'row1_door1',
        optionsName: 'door1_position',
        api: 'Vehicle.Cabin.Door.Row1.DriverSide.Position',
        unity_name: 'row1_door1_position',
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'position'
    },
    {
        entity: 'row1_door1',
        behaviour: "islocked",
        optionsName: 'door1_locked',
        api: 'Vehicle.Cabin.Door.Row1.DriverSide.IsLocked',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'row1_door2',
        optionsName: 'row1_door2_open',
        api: 'Vehicle.Cabin.Door.Row1.PassengerSide.IsOpen',
        unity_name: 'row1_door2',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'row1_door2',
        optionsName: 'door2_position',
        api: 'Vehicle.Cabin.Door.Row1.PassengerSide.Position',
        unity_name: 'row1_door2_position',
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'position'
    },
    {
        entity: 'row1_door2',
        behaviour: "islocked",
        optionsName: 'door2_locked',
        api: 'Vehicle.Cabin.Door.Row1.DriverSide.IsLocked',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'beam_high',
        optionsName: 'beam_high_open',
        api: 'Vehicle.Body.Lights.Beam.High.IsOn',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'beam_low',
        optionsName: 'beam_low_open',
        api: 'Vehicle.Body.Lights.Beam.Low.IsOn',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'trunk_rear',
        behaviour: "",
        optionsName: 'trunk_rear_open',
        api: 'Vehicle.Body.Trunk.Rear.IsOpen',
        unity_name: "trunk_rear",
        dataType: 'boolean',
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'trunk_rear',
        behaviour: "",
        optionsName: 'trunk_rear_position',
        api: 'Vehicle.Body.Trunk.Rear.Position',
        unity_name: "trunk_rear_position",
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: "position"
    },
    {
        entity: 'trunk_rear',
        behaviour: "islocked",
        optionsName: 'trunk_rear_islocked',
        api: 'Vehicle.Body.Trunk.Rear.IsLocked',
        unity_name: "",
        dataType: 'boolean',
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'rear_light',
        behaviour: "",
        optionsName: 'rear_light',
        api: 'Vehicle.Body.Trunk.Rear.IsLightOn',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'trunk_front',
        behaviour: "",
        optionsName: 'trunk_front_position',
        api: 'Vehicle.Body.Trunk.Front.Position',
        unity_name: "trunk_front_position",
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: "position"
    },
    {
        entity: 'trunk_front',
        behaviour: "",
        optionsName: 'trunk_front_isopen',
        unity_name: "trunk_front",
        api: 'Vehicle.Body.Trunk.Front.IsOpen',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'trunk_front',
        behaviour: "islocked",
        optionsName: 'trunk_front_islocked',
        api: 'Vehicle.Body.Trunk.Front.IsLocked',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'front_light',
        behaviour: "",
        optionsName: 'front_light',
        api: 'Vehicle.Body.Trunk.Front.IsLightOn',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'light_brake',
        optionsName: 'light_brake_active',
        api: 'Vehicle.Body.Lights.Brake.IsActive',
        dataType: 'string',
        lastValue: "INACTIVE",
        actionMaps: {
            "ACTIVE": "turn_on_brake",
            "INACTIVE": "turn_off_brake",
            "ADAPTIVE": "turn_on_brake",
        }
    },
    {
        entity: 'seat1',
        optionsName: 'seat1_height',  //variable name to get API       
        api: 'Vehicle.Cabin.Seat.Row1.DriverSide.Height',
        dataType: 'uint16',
        lastValue: 0,
        actionMaps: 'seat_height'
    },
    {
        entity: 'seat1',
        optionsName: 'seat1_position',
        api: 'Vehicle.Cabin.Seat.Row1.DriverSide.Position',
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'seat_position'
    },
    {
        entity: 'hazard_signaling',
        optionsName: 'hazard_signaling',
        api: 'Vehicle.Body.Lights.Hazard.IsSignaling',
        dataType: 'boolean',
        lastValue: false,
        actionMaps: {
            "true": "turn_on_signal",
            "false": "turn_off_signal"
        }
    },
    {
        entity: 'seat2',
        optionsName: 'seat2_position',
        api: 'Vehicle.Cabin.Seat.Row1.PassengerSide.Position',
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'seat_position'
    },
    {
        entity: 'seat2',
        optionsName: 'seat2_height',  //variable name to get API       
        api: 'Vehicle.Cabin.Seat.Row1.PassengerSide.Height',
        dataType: 'uint16',
        lastValue: 0,
        actionMaps: 'seat_height'
    },
    {
        entity: 'seat3',
        optionsName: 'seat3_position',
        api: 'Vehicle.Cabin.Seat.Row2.DriverSide.Position',
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'seat_position'
    },
    {
        entity: 'seat3',
        optionsName: 'seat3_height',  //variable name to get API       
        api: 'Vehicle.Cabin.Seat.Row2.DriverSide.Height',
        dataType: 'uint16',
        lastValue: 0,
        actionMaps: 'seat_height'
    },
    {
        entity: 'seat4',
        optionsName: 'seat4_position',
        api: 'Vehicle.Cabin.Seat.Row2.PassengerSide.Position',
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'seat_position'
    },
    {
        entity: 'seat4',
        optionsName: 'seat4_height',  //variable name to get API       
        api: 'Vehicle.Cabin.Seat.Row2.PassengerSide.Height',
        dataType: 'uint16',
        lastValue: 0,
        actionMaps: 'seat_height'
    },
    {
        entity: 'row2_door3',//param for Unity (entity)
        optionsName: 'row2_door3_open',//field on browser 
        api: 'Vehicle.Cabin.Door.Row2.DriverSide.IsOpen',
        unity_name: "row2_door3",
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",//value return from browser and value send to Unity (action)
            "false": "false"
        }
    },
    {
        entity: 'row2_door3',//param for Unity (entity)
        optionsName: 'door3_position',//field on browser 
        api: 'Vehicle.Cabin.Door.Row2.DriverSide.Position',
        unity_name: "row2_door3_position",
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'position'
    },
    {
        entity: 'row2_door3',
        behaviour: "islocked",
        optionsName: 'door3_locked',
        api: 'Vehicle.Cabin.Door.Row2.DriverSide.IsLocked',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false",
        },
    },
    {
        entity: 'row2_door4',
        behaviour: "",
        optionsName: 'row2_door4_open',
        api: 'Vehicle.Cabin.Door.Row2.PassengerSide.IsOpen',
        unity_name: "row2_door4",
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false",
        },
    },
    {
        entity: 'row2_door4',//param for Unity (entity)
        behaviour: "",
        optionsName: 'door4_position',//field on browser 
        api: 'Vehicle.Cabin.Door.Row2.PassengerSide.Position',
        unity_name: "row2_door4_position",
        dataType: 'uint8',
        lastValue: 0,
        actionMaps: 'position'
    },
    {
        entity: 'row2_door4',
        behaviour: "islocked",
        optionsName: 'door4_locked',
        api: 'Vehicle.Cabin.Door.Row2.PassengerSide.IsLocked',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false",
        },
    },
    {
        entity: 'wipper_front',
        optionsName: 'wipper_front',
        api: 'Vehicle.Body.Windshield.Front.Wiping.Mode',
        dataType: "string",
        lastValue: "OFF",
        actionMaps: ''
    },
    {
        entity: 'wipper_rear',
        optionsName: 'wipper_rear',
        api: 'Vehicle.Body.Windshield.Rear.Wiping.Mode',
        dataType: "string",
        lastValue: "OFF",
        actionMaps: 'mode'
    },
    {
        entity: 'mirror_left',
        optionsName: 'mirror_left_isfolded',
        api: 'Vehicle.Body.Mirrors.DriverSide.IsFolded',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'mirror_left',
        behaviour: "islocked",
        optionsName: 'mirror_left_islocked',
        api: 'Vehicle.Body.Mirrors.DriverSide.IsLocked',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'mirror_right',
        optionsName: 'mirror_right_isfolded',
        api: 'Vehicle.Body.Mirrors.PassengerSide.IsFolded',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'mirror_right',
        behaviour: "islocked",
        optionsName: 'mirror_right_islocked',
        api: 'Vehicle.Body.Mirrors.PassengerSide.IsLocked',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'window_1',
        optionsName: 'window_isopen',
        api: 'Vehicle.Cabin.Door.Row1.DriverSide.Window.IsOpen',
        unity_name: "window_1",
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'window_1',
        behaviour: "",
        optionsName: 'window1_position',
        api: 'Vehicle.Cabin.Door.Row1.DriverSide.Window.Position',
        unity_name: "window_1_position",
        dataType: "uint8",
        lastValue: 0,
        actionMaps: "position"
    },
    {
        entity: 'window_2',
        behaviour: "",
        optionsName: 'window2_isopen',
        api: 'Vehicle.Cabin.Door.Row1.PassengerSide.Window.IsOpen',
        unity_name: "window_2",
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'window_2',
        behaviour: "",
        optionsName: 'window2_position',
        api: 'Vehicle.Cabin.Door.Row1.PassengerSide.Window.Position',
        unity_name: "window_2_position",
        dataType: "uint8",
        lastValue: 0,
        actionMaps: "position"
    },
    {
        entity: 'window_3',
        behaviour: "",
        optionsName: 'window3_isopen',
        api: 'Vehicle.Cabin.Door.Row2.DriverSide.Window.IsOpen',
        unity_name: "window_3",
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'window_3',
        behaviour: "",
        optionsName: 'window3_position',
        api: 'Vehicle.Cabin.Door.Row2.DriverSide.Window.Position',
        unity_name: "window_3_position",
        dataType: "uint8",
        lastValue: 0,
        actionMaps: "position"
    },
    {
        entity: 'window_4',
        behaviour: "",
        optionsName: 'window4_isopen',
        api: 'Vehicle.Cabin.Door.Row2.PassengerSide.Window.IsOpen',
        unity_name: "window_4",
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'window_4',
        behaviour: "",
        optionsName: 'window4_position',
        api: 'Vehicle.Cabin.Door.Row2.PassengerSide.Window.Position',
        unity_name: "window_4_position",
        dataType: "uint8",
        lastValue: 0,
        actionMaps: "position"
    },
    {
        entity: 'ambientlight_1',
        optionsName: 'ambientlight_1_color',
        api: 'Vehicle.Cabin.Light.AmbientLight.Row1.DriverSide.Color',
        dataType: "string",
        lastValue: '#FF0000',
        actionMaps: 'set_color'
    },
    {
        entity: 'ambientlight_1',
        optionsName: 'ambientlight_1_ison',
        api: 'Vehicle.Cabin.Light.AmbientLight.Row1.DriverSide.IsLightOn',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'ambientlight_2',
        optionsName: 'ambientlight_2_color',
        api: 'Vehicle.Cabin.Light.AmbientLight.Row1.PassengerSide.Color',
        dataType: "string",
        lastValue: '#FF0000',
        actionMaps: 'set_color'
    },
    {
        entity: 'ambientlight_2',
        optionsName: 'ambientlight_2_ison',
        api: 'Vehicle.Cabin.Light.AmbientLight.Row1.PassengerSide.IsLightOn',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'wheels',
        behaviour: "",
        optionsName: 'wheels',
        api: 'Vehicle.AverageSpeed',
        dataType: "float",
        lastValue: 0,
        actionMaps: "speed"
    },
    {
        entity: 'license_plate',
        behaviour: "",
        optionsName: 'license_plate_light',
        api: 'Vehicle.Body.Lights.LicensePlate.IsOn',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
    {
        entity: 'air_bag',
        behaviour: "",
        optionsName: 'air_bag_light',
        api: 'Vehicle.Body.Horn.IsActive',
        dataType: "boolean",
        lastValue: false,
        actionMaps: {
            "true": "true",
            "false": "false"
        }
    },
]