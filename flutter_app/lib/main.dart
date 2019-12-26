import 'package:flutter/material.dart';
import 'package:flutter_app/models/location.dart';
import 'package:flutter_app/models/vehicleLocation.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'models/vehicleLocation.dart';
import 'widgets/location_input.dart';

void main() => runApp(MyApp());

class MyApp extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return MyAppState();
  }
}

class MyAppState extends State<MyApp> {
  String _route;
  int _totalVehicles;
  List<LocationModel> _locations;
  @override
  void initState() {
    super.initState();
    _route = _route ?? '100';
    _totalVehicles = 0;
  }

  getVehicles() {
    const agency = 'ttc';
    String route = _route;
    String url =
        'http://webservices.nextbus.com/service/publicJSONFeed?command=vehicleLocations&a=' +
            agency +
            '&r=' +
            route +
            '&t=1575543600';
    http.get(url).then((response) {
      var result = json.decode(response.body);
      var rawVehicles = result['vehicle'];
      var arrayVehicles = rawVehicles as List<dynamic>;
      if (arrayVehicles == null) {
        print("getVehicles - no vehicles");
        return;
      }
      var vehicleLocations = arrayVehicles.map((item) {
        return VehicleLocation.fromJson(item);
      }).toList();
      var locations = vehicleLocations.map((item) {
        return LocationModel.convert(item);
      }).toList();
      setState(() {
        _locations = locations;
        _totalVehicles = locations.length;
      });
      print("getVehicles - total=" + _totalVehicles.toString());
    });
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
          appBar: AppBar(
            title: Text("Bus Tracker"),
          ),
          body: Column(
            children: <Widget>[
              TextFormField(
                textAlign: TextAlign.center,
                decoration: InputDecoration(
                    border: InputBorder.none, hintText: 'Enter the route'),
                initialValue: _route,
                onChanged: (value) {
                  setState(() {
                    _route = value;
                  });
                },
              ),
              RaisedButton(
                child: Text('Get BUSES'),
                onPressed: () {
                  getVehicles();
                },
              ),
              _totalVehicles > 0
                  ? LocationInput(_locations)
                  : Text("No buses available")
            ],
          )),
    );
  }
}
